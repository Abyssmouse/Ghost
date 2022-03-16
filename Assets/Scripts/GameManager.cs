using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text LevelText;
    public Text UtilityTimer;

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

}
