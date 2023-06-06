using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template
{
	public sealed class CameraManager : MonoBehaviour
	{
		[SerializeField] StateMachine stateMachine;

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

		void GamePlay()
		{
			stateMachine.ChangeState(1);
		}
		void GameWin(int _reward)
		{
			stateMachine.ChangeState(0);
		}
		void GameLose(int _reward)
		{
			stateMachine.ChangeState(0);
		}

	}
}