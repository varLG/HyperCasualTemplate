using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template
{
	public sealed class GameManager : Singleton<GameManager>
	{
		StateMachine stateMachine;
		public bool gameActive;
		private void OnEnable()
		{
			EventManager.OnGameEnable += GameEnable;
			EventManager.OnGamePlay += GamePlay;
			EventManager.OnGameWin += GameWin;
			EventManager.OnGameLose += GameLose;
			EventManager.OnGameDisable += GameDisable;
		}

		private void OnDisable()
		{
			EventManager.OnGameEnable -= GameEnable;
			EventManager.OnGamePlay -= GamePlay;
			EventManager.OnGameWin -= GameWin;
			EventManager.OnGameLose -= GameLose;
			EventManager.OnGameDisable -= GameDisable;
		}

		private void Awake()
		{
			stateMachine = GetComponent<StateMachine>();

			Application.targetFrameRate = 60;
			Screen.sleepTimeout = SleepTimeout.NeverSleep;
		}

		private void Start()
		{
			EventManager.GameEnable();
		}

		void GameEnable()
		{
			stateMachine.ChangeState(0);
			gameActive = false;
		}
		void GamePlay()
		{
			stateMachine.ChangeState(1);
			gameActive = true;
		}
		void GameWin(int _reward)
		{
			stateMachine.ChangeState(2);
			gameActive = false;
		}
		void GameLose(int _reward)
		{
			stateMachine.ChangeState(3);
			gameActive = false;
		}
		void GameDisable()
		{
			stateMachine.ChangeState(4);
		}

	}
}