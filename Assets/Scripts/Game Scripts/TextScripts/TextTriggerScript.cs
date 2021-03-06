using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTriggerScript : MonoBehaviour
{
    // Placed on a empty trigger game object to use the colliders child text component

    private GameObject _playerText;
    private bool _onetime = false;

    [TextArea]
    public string Message;

    void Start()
    {
        _playerText = GameObject.FindWithTag("PlayerText");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag != "Player")
        {
            return;
        }

        if (!_onetime)
        {
           _onetime = true;
            _playerText.GetComponent<TextMesh>().text = Message;
        }
    }
}
