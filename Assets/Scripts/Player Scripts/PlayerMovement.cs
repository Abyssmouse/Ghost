using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 10.0f;

    [Space]
    [SerializeField] private string _horizontalMovementAxisName = "Horizontal";
    [SerializeField] private string _verticalMovementAxisName = "Vertical";

    private Rigidbody2D _rigidbody2d;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Transform _transform;
    private Animator _animator;
    private string _playerTag = "Player";
    private bool _isSneaking = true;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _transform = transform;
        _animator = GetComponent<Animator>();
        GameObject player = GameObject.FindGameObjectWithTag(_playerTag);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left ctrl"))
        {
            _animator.SetBool("IsSneaking",_isSneaking);
        }

        _horizontalMovement = Input.GetAxisRaw(_horizontalMovementAxisName);
        _verticalMovement = Input.GetAxisRaw(_verticalMovementAxisName);
        _rigidbody2d.velocity = new Vector2(_horizontalMovement * _speed, _verticalMovement * _speed);

        //IsWalking bool ne radi za vertikalno jos, bug jer dva puta u isto vrijeme može vratit true?

        if (_horizontalMovement != 0.0f)
        {
            _animator.SetBool("IsWalking", _horizontalMovement != 0.0f);
        }


    }

    private void LateUpdate()
    {
        Vector3 localScale = _transform.localScale;

        // && i operator (shift + 6)
        // || ili operator (altgr + w)
        if ((_horizontalMovement < 0.0f && localScale.x > 0.0f) ||
            (_horizontalMovement > 0.0f && localScale.x < 0.0f))
            localScale.x *= -1.0f;

        /*
		if (_horizontalMovement < 0.0f && localScale.x > 0.0f)
			localScale.x *= -1.0f;

		if (_horizontalMovement > 0.0f && localScale.x < 0.0f)
			localScale.x *= -1.0f;
		*/

        _transform.localScale = localScale;
    }
}
