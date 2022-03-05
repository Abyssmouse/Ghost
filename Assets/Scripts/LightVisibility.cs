using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightVisibility : MonoBehaviour
{

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
		}

	}
}
