using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour
{
	public GameObject ClosedEntrance;
	public GameObject OpenExit;
	private GameObject _playerText;
	private bool _isUnlocked = false;

	private void Awake()
	{
		SetIsLocked(true);
		_playerText = GameObject.FindWithTag("PlayerText");
	}

	public void SetIsLocked(bool value)
	{
		_isUnlocked = !value;

		ClosedEntrance.SetActive(!_isUnlocked);
		OpenExit.SetActive(_isUnlocked);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag != "Player")
		{
			return;
		}

		if (!_isUnlocked)

		{
			_playerText.GetComponent<TextMesh>().text = "The door is locked!";
			return;
		}

		int totalBuildIndex = SceneManager.sceneCountInBuildSettings;
		int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneBuildIndex + 1);

		if (currentSceneBuildIndex == (totalBuildIndex - 1))
		{
			//SceneManager.LoadScene("MainMenu");
		}
	}
}
