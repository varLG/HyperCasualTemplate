using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Template
{
	public sealed class EventManager
	{
		public static event Action OnGameEnable;

		public static event Action OnGamePlay;

		public static event Action<int> OnGameWin;

		public static event Action<int> OnGameLose;

		public static event Action OnGameDisable;

		public static event Action<int, Vector3> OnGainMoney;


		public static void GameEnable()
		{
			OnGameEnable?.Invoke();
		}

		public static void GamePlay()
		{
			OnGamePlay?.Invoke();
		}

		public static void GameWin(int _reward)
		{
			OnGameWin?.Invoke(_reward);
			//if (GameManager.Instance.StateMachineGame.CurrentStateIndex() == 1)
			//{
			//	if (GainedCoin <= 0)
			//		GainedCoin = 10;

			//	OnGameWin?.Invoke(GainedCoin);
			//}
			//else
			//{
			//	Debug.Log("Game is not playing!");
			//}
		}

		public static void GameLose(int _reward)
		{
			OnGameLose?.Invoke(_reward);
			//if (GameManager.Instance.StateMachineGame.CurrentStateIndex() == 1)
			//{
			//	if (GainedCoin <= 0)
			//		GainedCoin = 10;

			//	OnGameLose?.Invoke(GainedCoin);
			//}
			//else
			//{
			//	Debug.Log("Game is not playing!");
			//}
		}

		public static void GameDisable()
		{
			OnGameDisable?.Invoke();
		}

		public static void GainMoney(int _gainedMoney, Vector3 _worldPos)
		{
			OnGainMoney?.Invoke(_gainedMoney, _worldPos);

		}
	}
}