using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionInvisibility : MonoBehaviour
{
    public float timeRemaining;

    private SpriteRenderer _spriteRenderer;
	private PlayerAttributes _playerAttributes = null;
	private Animator _playerAnimator;

    private void Awake()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player != null)
		{
			_playerAttributes = player.GetComponent<PlayerAttributes>();
		}
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
            _playerAnimator.SetBool("IsGhost", true);

			if (_playerAttributes != null)
			{
				_playerAttributes.SetCloaked(true);
			}
        }

        if (timeRemaining <= 0)
        {
            _playerAnimator.SetBool("IsGhost", false);

			if (_playerAttributes != null)
			{
				_playerAttributes.SetCloaked(false);
			}
		}
    }
}
