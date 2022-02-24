using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

// Create a Canvas that holds a Text GameObject.

public class GuardTextBehavior : MonoBehaviour
{
    public Text GuardText;
    private RectTransform _rectTransform;
    private GameObject _guard;

    void Awake()
    {
        _rectTransform = GuardText.GetComponent<RectTransform>();
    }

    void Start()
    {
        _guard = GameObject.FindGameObjectWithTag("Guard");
    }

    void Update()
    {
        _rectTransform.position = _guard.transform.localPosition;
    }

}