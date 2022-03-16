using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightVisibility : MonoBehaviour
{
	private Collider2D _target = null;
	private CircleCollider2D _circle = null;
	private PlayerAttributes _playerAttributes = null;

	private void Awake()
    {
		_circle = GetComponent<CircleCollider2D>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			return;
		}

		_target = other;
		_playerAttributes = other.GetComponent<PlayerAttributes>();
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			return;
		}

		_target = null;
		_playerAttributes = null;
	}

	private void Update()
	{
		if (_target != null && _circle != null && _playerAttributes != null)
		{
			//calculate distance from trigger edge
			Vector3 toCenter3D = _target.transform.position - _circle.transform.position;
			Vector2 toCenter = new Vector2(toCenter3D.x, toCenter3D.y);
			//distance from the center of the _circle
			float distance = toCenter.magnitude;
			//distanceNormalized is 0.0f when _target is in center of the _circle, and 1.0f if _target is exactly on the circle
			float distanceNormalized = distance / _circle.radius;

			//1.0f - distanceNormalized means that if distNorm is 0.0f, then 1.0 - distNorm will be 1.0f
			//									   if distNorm is 0.5f, then 1.0f - distNorm will be 0.5f
			//									   if distNorm is 1.0f, then 1.0f - distNorm will be 0.0f
			// Math.Clamp(x, 0.0f, 1.0f) clamps the x value to be between 0.0f and 1.0f
			float additionalVisibility = Mathf.Clamp(1.0f - distanceNormalized, 0.0f, 1.0f);

			//set visibility to player attribute
			_playerAttributes.SetAdditionalVisibiity(additionalVisibility);
		}
	}
}
