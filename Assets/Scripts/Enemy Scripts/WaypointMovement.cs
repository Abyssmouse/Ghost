using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
	[SerializeField] private Transform _targetTransform;
	[SerializeField] private float _speed = 2.5f;
	[SerializeField] private float _waitAtWaypointDuration = 1.5f;
	[SerializeField] private List<Transform> _waypoints;

	[Header("Read-only")]
	[SerializeField] private int _waypointIndex = 0;
	[SerializeField] private float _moveTime;

	//Bilo bi fora: napraviti flipanje sprajta, da se zrcali i animira u drugom smjeru

	private void Update()
	{
		if (Time.time < _moveTime)
			return;

		_targetTransform.position = Vector3.MoveTowards(_targetTransform.position, _waypoints[_waypointIndex].position, _speed * Time.deltaTime);

		float distanceToTarget = Vector3.Distance(_targetTransform.position, _waypoints[_waypointIndex].position);

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
