using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Template
{
	public sealed class UIDeveloper : MonoBehaviour
	{
		[Header("Canvas")]
		[SerializeField] Canvas canvas;


		[Header("Reward Amount")]
		[SerializeField] Button btnWin;
		[SerializeField] Button btnLose;

		[Header("Reward Amount")]
		[SerializeField] int winReward;
		[SerializeField] int loseReward;

		private void OnEnable()
		{
			EventManager.OnGamePlay += GamePlay;
			EventManager.OnGameWin += GameWin;
			EventManager.OnGameLose += GameLose;
		}

		private void OnDisable()
		{
			EventManager.OnGamePlay -= GamePlay;
			EventManager.OnGameWin -= GameWin;
			EventManager.OnGameLose -= GameLose; 
		}
		void Start()
		{
			btnWin.onClick.AddListener(ClickButtonWin);
			btnLose.onClick.AddListener(ClickButtonLose);
		}

		void GamePlay()
		{
			canvas.enabled = true;
		}
		void GameWin(int _reward)
		{
			canvas.enabled = false;
		} 
		void GameLose(int _reward)
		{
			canvas.enabled = false;
		}

		void ClickButtonWin()
		{
			EventManager.GameWin(winReward);
		}

		void ClickButtonLose()
		{
			EventManager.GameLose(loseReward);
		}


	}
}