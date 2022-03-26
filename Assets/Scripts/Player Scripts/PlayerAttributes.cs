using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{
	public float BasePlayerVisibility { get; } = 0.2f;
	private float _playerVisibility = 0.2f;
	private float _additionalVisibility = 0.0f;
	private float _cloakedTimer = 0.0f;
	private float _enhancedVisibilityTimer = 0.0f;
	private GameObject _uivisibility = null;
	private Animator _playerAnimator = null;
	private GameObject _mainCamera = null;

	private void Awake()
	{
		_playerVisibility = BasePlayerVisibility;
		_uivisibility = GameObject.FindGameObjectWithTag("UIVisibility");
		_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(player)
			_playerAnimator = player.GetComponent<Animator>();
	}
	
	public void SetAdditionalVisibiity(float visibility)
	{
		//increasing player visibility from BasePlayerVisibility towards 1.0f, based on input visibilty
		_playerVisibility = Mathf.Lerp(BasePlayerVisibility, 1.0f, visibility);
		_additionalVisibility = visibility;

		if (_uivisibility != null)
		{	
			_uivisibility.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, _playerVisibility);
		}
	}
	public float GetPlayerVisibility() { return _playerVisibility; }
	public float GetAdditionalPlayerVisibility() { return _additionalVisibility; }

	public void AddCloakTime(float time) { _cloakedTimer += time; }
	public bool IsCloaked() { return _cloakedTimer > 0.0f; }

	public void AddEnhancedVisibilityTime(float time) { _enhancedVisibilityTimer += time; }
	public bool HasEnhancedVisibility() { return _enhancedVisibilityTimer > 0.0f; }

	public void Update()
	{
		if (_cloakedTimer > 0.0f)
		{ 
			_cloakedTimer -= Time.deltaTime;
			
			_playerAnimator.SetBool("IsGhost", IsCloaked()); //IsCloaked() returns _cloakedTimer > 0.0f
		}

		if (_enhancedVisibilityTimer > 0.0f)
		{ 
			_enhancedVisibilityTimer -= Time.deltaTime;
			
			if(HasEnhancedVisibility()) //if still has enhanced visibilty then keep orthographicSize to 7
				Camera.main.orthographicSize = 7;
			else //else return to default of 5.5
				Camera.main.orthographicSize = 5.5f;
		}
	}
}
