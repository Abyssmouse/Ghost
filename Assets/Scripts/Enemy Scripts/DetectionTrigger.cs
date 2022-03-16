using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionTrigger : MonoBehaviour
{
	public string ActivatedScriptName = "TargetMover";
	public string DeactivatedScriptName = "";
	private CircleCollider2D _triggerRadius;
		
	private void Awake()
    {
		_triggerRadius = GetComponent<CircleCollider2D>();
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

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			return;
		}

		ToggleBehaviour(ActivatedScriptName, DeactivatedScriptName, other);
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			return;
		}

		ToggleBehaviour(DeactivatedScriptName, ActivatedScriptName, other);
	}
}
