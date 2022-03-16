using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    [Space]
    [SerializeField] private string _horizontalMovementAxisName = "Horizontal";
    [SerializeField] private string _verticalMovementAxisName = "Vertical";

    private Rigidbody2D _rigidbody2d;
    private float _horizontalMovement;
    private float _verticalMovement;
    private Transform _transform;
    private Animator _animator;
    private Transform _textMeshTransform = null;
    private PlayerAttributes _playerAttributes;


    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _transform = transform;
        _animator = GetComponent<Animator>();
        _playerAttributes = GetComponent<PlayerAttributes>();
    }

    private void Start()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform t = transform.GetChild(i);
            if (t.name == "PlayerText")
            {
                _textMeshTransform = t;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey("left ctrl"))
            {
                _animator.SetBool("IsSneaking", true);
                _speed = 1.0f;
            }
            else
            {
                _animator.SetBool("IsSneaking", false);
                _speed = 5.0f;
            }

        _horizontalMovement = Input.GetAxisRaw(_horizontalMovementAxisName);
        _verticalMovement = Input.GetAxisRaw(_verticalMovementAxisName);
        _rigidbody2d.velocity = new Vector2(_horizontalMovement * _speed, _verticalMovement * _speed);

        if (_horizontalMovement != 0.0f) ;
        {
            _animator.SetBool("IsWalking", _horizontalMovement != 0.0f);
        }
    }

    private void LateUpdate()
    {
        Vector2 localScale = _transform.localScale;

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

        if (_textMeshTransform != null)
        {
            _textMeshTransform.localScale = localScale;
        }
    }
}
