using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text LevelText;

    private void Awake()
    {
        LevelText.text = "LEVEL: " + SceneManager.GetActiveScene().name;
    }

    void Update()
    {

    }
}
