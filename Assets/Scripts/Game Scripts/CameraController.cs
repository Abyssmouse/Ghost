using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Vector3 _offset;

	private PlayerMovement _playerMovement;

	private void Awake()
	{
		_playerMovement = FindObjectOfType<PlayerMovement>();
	}

	private void LateUpdate()
	{
		if (_playerMovement == null)
			return;

		transform.position = _playerMovement.transform.position + _offset;
	}
}
