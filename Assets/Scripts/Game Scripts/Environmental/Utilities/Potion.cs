using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
	public enum EPotionType { None, Invisibility, Insight };

	public EPotionType type = EPotionType.None;
	public float time = 10.0f;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag != "Player")
		{
			return;
		}
		else
		{
			PlayerAttributes playerAttributes = other.GetComponent<PlayerAttributes>();
			if (playerAttributes != null)
			{
				//switch based on potion type to increase correct timer
				switch (type)
				{
					case EPotionType.None:
						break;

					case EPotionType.Invisibility:
						playerAttributes.AddCloakTime(time);
						GameManager.Instance.UpdateTimer(time);
						break;

					case EPotionType.Insight:
						playerAttributes.AddEnhancedVisibilityTime(time);
						GameManager.Instance.UpdateTimer(time);
						break;

					default:
						break;
				}
			}

			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			Destroy(spriteRenderer); //destroy sprite
			Destroy(this); //destroy self
		}
	}
}
