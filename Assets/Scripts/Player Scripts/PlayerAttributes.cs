using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
	public float BasePlayerVisibility { get; } = 0.2f;
	private float _playerVisibility = 0.2f;
	private float _additionalVisibility = 0.0f;
	private bool _isCloaked = false;
	private GameObject _uivisibility = null;

	private void Awake()
	{
		_playerVisibility = BasePlayerVisibility;
		_uivisibility = GameObject.FindGameObjectWithTag("UIVisibility");
	}

	public void SetAdditionalVisibiity(float visibility)
	{
		_playerVisibility = Mathf.Lerp(BasePlayerVisibility, 1.0f, visibility);
		_additionalVisibility = visibility;

		if (_uivisibility != null)
		{
			_uivisibility.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, _playerVisibility);
		}
	}
	public float GetPlayerVisibility() { return _playerVisibility; }
	public float GetAdditionalPlayerVisibility() { return _additionalVisibility; }

	public void SetCloaked(bool cloaked) { _isCloaked = cloaked; }
	public bool IsCloaked() { return _isCloaked; }
}
