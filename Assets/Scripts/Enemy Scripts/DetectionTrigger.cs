using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionTrigger : MonoBehaviour
{
    public Transform Player;
    public float Speed = 4.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            return;
        }
    }

    private void Update()
    {
        if (Player == null)
        {
            return;
        }
        transform.LookAt(Player);
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
}
