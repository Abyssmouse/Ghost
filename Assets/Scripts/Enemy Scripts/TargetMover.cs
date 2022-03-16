using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MoverBehaviour
{
	[SerializeField] private Animator _animator;
	public float Speed = 4.0f;
	private Rigidbody2D _rigidbody2D = null;
	private TextMesh _guardText;
	public float _timetoClearText = 3.0f;


	void Start()
	{
	}

	void Awake()
	{
		_animator = GetComponent<Animator>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_guardText = GetComponentInChildren<TextMesh>();
	}

	void Update()
    {

		if (Target == null)
		{
			_guardText.text = "";
			return;
		}

		_guardText.text = "Halt!";

		Vector3 toTarget = Target.transform.position - transform.position;
		toTarget.z = 0.0f;
		toTarget.Normalize();

		transform.position += toTarget * Speed * Time.deltaTime;
		_animator.SetBool("IsWalking", true);

		float targetSide = Mathf.Sign(Target.transform.position.x - transform.position.x);

		Vector3 localScale = transform.localScale;
		localScale.x = targetSide;
		transform.localScale = localScale;

		if (_guardText != null)
		{
			_guardText.transform.localScale = localScale;
		}
	}
}
