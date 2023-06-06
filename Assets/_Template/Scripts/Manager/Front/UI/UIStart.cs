using System.Collections;
using System.Collections.Generic;
using Template;
using UnityEngine;
using UnityEngine.UI;

namespace Template { 
public sealed class UIStart : MonoBehaviour
{
	[Header("Canvas")]
	[SerializeField] Canvas canvas;

	[Header("UI")]
	[SerializeField] Button btnStart;

	private void OnEnable()
	{
		EventManager.OnGameEnable += GameEnable;
		EventManager.OnGamePlay += GamePlay; 
	}

	private void OnDisable()
	{
		EventManager.OnGameEnable -= GameEnable;
		EventManager.OnGamePlay -= GamePlay; 
	}

	private void Awake()
	{
		btnStart.onClick.AddListener(ClickButtonStart);
	}

	void GameEnable()
	{
		canvas.enabled = true;
	}
	void GamePlay()
	{
		canvas.enabled = false;
	} 

	void ClickButtonStart()
	{
		EventManager.GamePlay();
	}
}
}