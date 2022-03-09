using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSortingPriorityPlayer : MonoBehaviour
{
    private GameObject _text;
    private MeshRenderer _meshRenderer;

    void Awake()
    {
        _text = GameObject.FindGameObjectWithTag("PlayerText");
        _meshRenderer = _text.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _meshRenderer.sortingLayerName = "Foreground";
    }
}
