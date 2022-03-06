using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MoverBehaviour
{
	[SerializeField] private Animator _animator;
	public float Speed = 4.0f;
	private Rigidbody2D _rigidbody2D = null;
	private TextMesh _guardText;
	public float _timetoClearText = 5.0f;
	private Transform _textMeshTransform = null;

	void Start()
	{
		_timetoClearText = Time.time;
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
			return;
		}

		_guardText.text = "Halt!";

		if (_timetoClearText <= 0.0f)
		{
			_timetoClearText = 5.0f;
			_guardText.text = "";
		}

		Vector3 toTarget = Target.transform.position - transform.position;
		toTarget.z = 0.0f;
		toTarget.Normalize();

		transform.position += toTarget * Speed * Time.deltaTime;
		_animator.SetBool("IsWalking", true);

		if (Target.transform.position.x <= transform.position.x)
        {
			Vector3 localScale = transform.localScale;
			localScale.x = -1.0f;
			transform.localScale = localScale;
		}






	}
}
