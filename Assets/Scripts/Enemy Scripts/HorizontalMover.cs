using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HorizontalMover : MonoBehaviour
{
	[SerializeField] private Transform _flipCheckStart;
	[SerializeField] private Transform _flipCheckEnd;
	[SerializeField] private LayerMask _flipLayerMask;
	[Space]
	[SerializeField] private float _speed = 2.5f;

	private Rigidbody2D _rigidbody2D;

	private float _xDirection = 1.0f;

	private void Awake()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		_rigidbody2D.velocity = new Vector2(_xDirection * _speed, _rigidbody2D.velocity.y);
		bool shouldFlip = Physics2D.Linecast(_flipCheckStart.position, _flipCheckEnd.position, _flipLayerMask);

		if(shouldFlip)
		{
			_xDirection *= -1.0f;

			Vector3 localScale = transform.localScale;
			localScale.x *= -1.0f;

			transform.localScale = localScale;
		}
	}

	private void OnDrawGizmos()
	{
		if(_flipCheckStart == null || _flipCheckEnd == null)
			return;

		Gizmos.color = Color.gray;
		Gizmos.DrawLine(_flipCheckStart.position, _flipCheckEnd.position);
	}
}
