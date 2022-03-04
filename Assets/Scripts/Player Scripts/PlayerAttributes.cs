using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public float _playerVisibility = 0.0f;
    
    public void VisibilityInc()
    {
        _playerVisibility += 0.5f;
    }

    public void VisibilityDec()
    {
        _playerVisibility -= 0.5f;
    }

}
