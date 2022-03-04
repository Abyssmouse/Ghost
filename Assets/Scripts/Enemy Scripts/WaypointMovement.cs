using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MoverBehaviour
{
	private Transform _textMeshTransform = null;
	[SerializeField] private Transform _targetTransform;
	[SerializeField] private float _speed = 2.5f;
	[SerializeField] private float _waitAtWaypointDuration = 1.5f;
	[SerializeField] private List<Transform> _waypoints;

	[Header("Read-only")]
	[SerializeField] private int _waypointIndex = 0;
	[SerializeField] private float _moveTime;
	[SerializeField] private Animator _animator;

	void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	private void Start()
	{
		for (int i = 0; i < transform.childCount; ++i)
		{
			Transform t = transform.GetChild(i);
			if (t.name == "GuardText")
			{
				_textMeshTransform = t;
				break;
			}
		}
	}
	private void Update()
	{
		if (Time.time < _moveTime)
			return;

		_targetTransform.position = Vector2.MoveTowards(_targetTransform.position, _waypoints[_waypointIndex].position, _speed * Time.deltaTime);
		_animator.SetBool("IsWalking", true);

		float distanceToTarget = Vector2.Distance(_targetTransform.position, _waypoints[_waypointIndex].position);

		if(distanceToTarget <= Mathf.Epsilon)
		{
			_waypointIndex++;
			// % modulo operator
			_waypointIndex %= _waypoints.Count;

			//if(_waypointIndex >= _waypoints.Count)
			//{
			//	_waypointIndex = 0;
			//}

			_moveTime = Time.time + _waitAtWaypointDuration;
			_animator.SetBool("IsWalking", false);
		}

        if (_waypointIndex == 3)
        {
			Vector3 localScale = transform.localScale;
			localScale.x = -1.0f;

			transform.localScale = localScale;
			if (_textMeshTransform != null)
			{
				_textMeshTransform.localScale = localScale;
			}
		}

		if (_waypointIndex == 1)
		{
			Vector3 localScale = transform.localScale;
			localScale.x = 1.0f;

			transform.localScale = localScale;
			if (_textMeshTransform != null)
			{
				_textMeshTransform.localScale = localScale;
			}
		}

	}

	private void OnDrawGizmos()
	{
		if (_waypoints.Count == 0)
			return;

		Gizmos.color = new Color(0.5f, 0.5f, 0.0f);

		for (int i = 0; i < _waypoints.Count - 1; i++)
		{
			Gizmos.DrawLine(_waypoints[i].position, _waypoints[i + 1].position);
		}

		Gizmos.DrawLine(_waypoints[_waypoints.Count - 1].position, _waypoints[0].position);
	}
}
