using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public Vector3 RespawnPosition;
    public string MainMenu = "MainMenu";

    public void Die()
    {

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SceneManager.LoadScene("MainMenu");
    }



}
