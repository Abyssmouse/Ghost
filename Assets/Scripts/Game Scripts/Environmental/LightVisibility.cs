using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightVisibility : MonoBehaviour
{
	private GameObject _uivisibility;

	private void Awake()
    {
		_uivisibility = GameObject.FindGameObjectWithTag("UIVisibility");
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			return;
		}

		PlayerAttributes playerAttributes = other.GetComponent<PlayerAttributes>();

		if (playerAttributes != null)
		{
			playerAttributes.VisibilityInc();
			//_uivisibility.GetComponent<Image>().color = new Color32(255, 255, 255, 150);
			Color32 color = _uivisibility.GetComponent<Image>().color;
			color.a += 50;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			return;
		}

		PlayerAttributes playerAttributes = other.GetComponent<PlayerAttributes>();

		if (playerAttributes != null)
		{
			playerAttributes.VisibilityDec();
			//_uivisibility.GetComponent<Image>().color = new Color32(255, 255, 255, 50);
			Color32 color = _uivisibility.GetComponent<Image>().color;
			color.a -= 50;
		}

	}
}
