using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
	public bool isUsed;

	private Animator _animator;

	void Awake()
	{
		_animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			return;
		}

		if (other.tag == "Player")
		{
			_animator.SetBool("IsUsed", true);
			isUsed = true;
		}
	}
}
