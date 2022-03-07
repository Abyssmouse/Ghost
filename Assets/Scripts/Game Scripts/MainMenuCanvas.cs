using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{

    public string FirstSceneName = "Level01";

        public void Play()
        {
            SceneManager.LoadScene(FirstSceneName);
        }
        
        public void Quit()
        {
            Application.Quit();
        }
   
}
