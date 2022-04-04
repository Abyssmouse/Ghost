using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text LevelText;
    public Text UtilityTimerText;

    private float _timer = 0.0f;

    private void Awake()
    {
        Instance = this;
        LevelText.text = "LEVEL: " + SceneManager.GetActiveScene().name;
    }

    public void TargetUnlocked()
    {
            EntranceExit entranceExit = FindObjectOfType<EntranceExit>();

            if (entranceExit != null)
            {
                entranceExit.SetIsLocked(false);
            }
    }

    private void Update()
    {
        if (_timer <= 0)
        {
            _timer = 0.0f;
            UtilityTimerText.text = " ";
            return;
        }
        UpdateTimer(-Time.deltaTime);
    }

    public void UpdateTimer(float value)
    {
        _timer += value; 
        UtilityTimerText.text = _timer.ToString("F1");
    }
}
