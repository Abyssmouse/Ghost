using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HorizontalMover : MoverBehaviour
{
	[SerializeField] private Transform _flipCheckStart;
	[SerializeField] private Transform _flipCheckEnd;
	[SerializeField] private LayerMask _flipLayerMask;
	[Space]
	[SerializeField] private float _speed = 2.5f;

	public bool useChaoticMovementAtRandom = true;

	private Rigidbody2D _rigidbody2D = null;
	private Transform _textMeshTransform = null;
	private BoxCollider2D _boxCollider2D = null;

	private Vector3 _positionLastFrame;

	private float _xDirection = 1.0f;

	private void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_positionLastFrame = transform.position;

		_boxCollider2D = GetComponent<BoxCollider2D>();

		for (int i = 0; i < transform.childCount; ++i)
		{
			Transform t = transform.GetChild(i);
			if(t.name == "GuardText")
			{
				_textMeshTransform = t;
				break;
			}
		}
	}

	private void FixedUpdate()
	{
		_rigidbody2D.velocity = new Vector2(_xDirection * _speed, _rigidbody2D.velocity.y);

		if (useChaoticMovementAtRandom == true)
		{
			bool isSamePosition = (_positionLastFrame - transform.position).sqrMagnitude < Mathf.Pow(0.001f, 2.0f);
			bool doRandom = Random.Range(0, 128) == 0;
			if (isSamePosition || doRandom)
			{
				_rigidbody2D.velocity = _speed * new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
			}
		}

		bool shouldFlip = Physics2D.Linecast(_flipCheckStart.position, _flipCheckEnd.position, _flipLayerMask);

		if(shouldFlip)
		{
			_xDirection *= -1.0f;

			Vector3 localScale = transform.localScale;
			localScale.x *= -1.0f;

			transform.localScale = localScale;

			//Keep the text in right direction
			if (_textMeshTransform != null)
			{
				_textMeshTransform.localScale = localScale;
			}
		}

		_positionLastFrame = transform.position;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Guard")
		{
			Physics2D.IgnoreCollision(collision.collider, _boxCollider2D);
		}
	}
	private void OnDrawGizmos()
	{
		if(_flipCheckStart == null || _flipCheckEnd == null)
			return;

		Gizmos.color = Color.gray;
		Gizmos.DrawLine(_flipCheckStart.position, _flipCheckEnd.position);
	}

	public override void OnBehaviourAttached() { }

	public override void OnBehaviourDetached()
	{
		_rigidbody2D.velocity = new Vector2(0, 0);
	}
}
