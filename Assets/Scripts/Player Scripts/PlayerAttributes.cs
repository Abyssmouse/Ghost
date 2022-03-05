using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public float PlayerVisibility = 0.0f;
    private string _triggerTag = "DetectionTrigger";
    private CircleCollider2D _circleCollider2D;

    private void Awake()
    {
        GameObject DetectionTrigger = GameObject.FindGameObjectWithTag(_triggerTag);
        _circleCollider2D = DetectionTrigger.GetComponent<CircleCollider2D>();
    }

    public void VisibilityInc()
    {
        PlayerVisibility += 1.0f;
        _circleCollider2D.radius += 1.0f;
    }

    public void VisibilityDec()
    {
        PlayerVisibility -= 1.0f;
        _circleCollider2D.radius -= 1.0f;
    }
}
