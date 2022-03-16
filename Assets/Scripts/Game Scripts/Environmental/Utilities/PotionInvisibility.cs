using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionInvisibility : MonoBehaviour
{
    public float timeRemaining;

    private SpriteRenderer _spriteRenderer;
    private string _triggerTag = "DetectionTrigger";
    private CircleCollider2D _circleCollider2D;
    private Animator _playerAnimator;

    private void Awake()
    {
        GameObject DetectionTrigger = GameObject.FindGameObjectWithTag(_triggerTag);
        _circleCollider2D = DetectionTrigger.GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            return;
        }

        _playerAnimator = other.GetComponent<Animator>();

        timeRemaining = 10;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;

    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            _circleCollider2D.radius = 0.0f;
            _playerAnimator.SetBool("IsGhost", true);
        }

        if (timeRemaining <= 0)
        {
            _circleCollider2D.radius = 4.0f;
            _playerAnimator.SetBool("IsGhost", false);
        }
    }
}
