using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template
{
	public sealed class DataManager : MonoBehaviour
	{
		public static int level
		{
			get { return PlayerPrefs.GetInt("level") + 1; }
			private set { PlayerPrefs.SetInt("level", value - 1); }
		}

		public static int money
		{
			get { return PlayerPrefs.GetInt("money"); }
			private set { PlayerPrefs.SetInt("money", value); }
		}

		public static bool sound
		{
			get
			{
				if (PlayerPrefs.GetInt("sound") == 0)
					return true;
				else
					return false;
			}
			set
			{

				if (sound)
				{
					PlayerPrefs.SetInt("sound", 1);
					AudioListener.pause = true;
				}
				else
				{
					PlayerPrefs.SetInt("sound", 0);
					AudioListener.pause = false;
				}
			}
		}

		public static bool haptic
		{
			get
			{
				if (PlayerPrefs.GetInt("haptic") == 0)
					return true;
				else
					return false;
			}
			set
			{

				if (haptic)
				{
					PlayerPrefs.SetInt("haptic", 1);
					Vibration.hapticActive = false;
				}
				else
				{
					PlayerPrefs.SetInt("haptic", 0);
					Vibration.hapticActive = true;
				}


			}
		} 
		private void OnEnable()
		{
			EventManager.OnGameWin += GameWin;
			EventManager.OnGameLose += GameLose;
			EventManager.OnGainMoney += GainMoney;
		}

		private void OnDisable()
		{
			EventManager.OnGameWin -= GameWin;
			EventManager.OnGameLose -= GameLose;
			EventManager.OnGainMoney -= GainMoney;
		}

		private void Awake()
		{
			Vibration.hapticActive = haptic;
			AudioListener.pause = !sound;
		}

		void GameWin(int _reward)
		{ 
			money += _reward;
			level++;
		}
		void GameLose(int _reward)
		{ 
			money += _reward;
		}

		void GainMoney(int _gainMoney, Vector3 _worldPos)
		{
			money += _gainMoney; 
		}
	}
}