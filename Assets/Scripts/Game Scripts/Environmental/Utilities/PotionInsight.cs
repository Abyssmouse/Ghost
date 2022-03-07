using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionInsight : MonoBehaviour
{
    public float timeRemaining;
    private SpriteRenderer _spriteRenderer;
    private GameObject _mainCamera;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag != "Player")
        {
            return;
        }

        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        if (_mainCamera != null)
        {
            Camera.main.orthographicSize = 7;
            timeRemaining = 10;
        }
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;

    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining <= 0)
        {
            Camera.main.orthographicSize = 5.5f;
            //Destroy(gameObject);
        }
    }
}
