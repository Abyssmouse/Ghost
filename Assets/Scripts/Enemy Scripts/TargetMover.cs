using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MoverBehaviour
{
	public float Speed = 4.0f;
	private Rigidbody2D _rigidbody2D = null;

	// Start is called before the first frame update
	void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update()
    {
		if (Target == null)
		{
			return;
		}

		Vector3 toTarget = Target.transform.position - transform.position;
		toTarget.z = 0.0f;
		toTarget.Normalize();

		transform.position += toTarget * Speed * Time.deltaTime;

	}
}
