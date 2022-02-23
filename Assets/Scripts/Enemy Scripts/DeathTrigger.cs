using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			return;
		}

        PlayerLives playerLives = other.GetComponent<PlayerLives>();

        if (playerLives != null)
        {
            playerLives.Die();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
