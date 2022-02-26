using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
	public bool isUsed;

	private Animator _animator;
	private GameObject _playerText;

	void Awake()
	{
		_animator = GetComponent<Animator>();
		_playerText = GameObject.FindWithTag("PlayerText");
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			return;
		}

		if (other.tag == "Player")
		{
			_playerText.GetComponent<TextMesh>().text = "Now to disappear...";
			_animator.SetBool("IsUsed", true);
			isUsed = true;
		}
	}
}
