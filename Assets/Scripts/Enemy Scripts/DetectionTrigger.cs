using UnityEngine;

public class DetectionTrigger : MonoBehaviour
{
	public string ActivatedScriptName = "TargetMover";
	public string DeactivatedScriptName = "";
	private CircleCollider2D _triggerRadius = null;
	private PlayerAttributes _playerAttributes = null;
	public float BaseRadius = 4.0f;
	public float MaxRadius = 6.0f;
	[SerializeField] private LayerMask _raycastLayerMask;

	private void Awake()
    {
		_triggerRadius = GetComponent<CircleCollider2D>();
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player != null)
		{
			_playerAttributes = player.GetComponent<PlayerAttributes>();
		}
	}
	
	private void ToggleBehaviour(string active, string deactive, Component target)
	{
		MoverBehaviour[] monoBehaviours = transform.gameObject.transform.parent.GetComponents<MoverBehaviour>();
		foreach (MoverBehaviour behaviour in monoBehaviours)
		{
			if (behaviour == null)
			{
				continue;
			}

			if (behaviour.GetType() == System.Type.GetType(deactive))
			{
				behaviour.OnBehaviourDetached();
				behaviour.enabled = false;
				behaviour.Target = null;
			}
			else if (behaviour.GetType() == System.Type.GetType(active))
			{
				behaviour.enabled = true;
				behaviour.Target = target;
				behaviour.OnBehaviourAttached();
			}
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag != "Player" || _triggerRadius == null)
		{
			return;
		}

		Vector2 rayStart = transform.position;
		Vector2 rayDir = other.transform.position - transform.position;
		float distanceToPlayer = rayDir.magnitude;
		rayDir.Normalize();

		//raycast in the direction of the player, with distance of distanceToPlayer or _triggerRadus.radius (whichever is closer)
		RaycastHit2D hit = Physics2D.Raycast(rayStart, rayDir, Mathf.Min(distanceToPlayer, _triggerRadius.radius), _raycastLayerMask);
		
		//we're interested if there is nothing between this guard and the player (so the player is visible then)
		if (hit.collider == null)
		{
			ToggleBehaviour(ActivatedScriptName, DeactivatedScriptName, other);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			return;
		}

		ToggleBehaviour(DeactivatedScriptName, ActivatedScriptName, other);
	}

	private void Update()
	{
		if (_playerAttributes != null && _triggerRadius != null)
		{
			if (_playerAttributes.IsCloaked())
				_triggerRadius.radius = 0.0f;
			else
				_triggerRadius.radius = Mathf.Lerp(BaseRadius, MaxRadius, _playerAttributes.GetAdditionalPlayerVisibility());

		}
	}
}
