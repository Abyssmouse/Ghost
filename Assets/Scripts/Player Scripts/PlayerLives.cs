using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    public int Lives = 3;
    public Vector3 RespawnPosition;
    public string Sandbox = "Sandbox";

    public void Awake()
    {
        RespawnPosition = transform.position;
    }

    public void Die()
    {

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        Lives--;

        if (Lives > 0)
        {
            transform.position = RespawnPosition;
        }
        else
        {
            SceneManager.LoadScene("Sandbox");
        }
    }



}
