using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Template
{
	public sealed class HapticManager : MonoBehaviour
	{  
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
		private void Start()
		{
			Vibration.Init();
			foreach (Button item in Resources.FindObjectsOfTypeAll<Button>())
			{
				item.onClick.AddListener(() => ButtonHaptic(item));
			}
		}
		void GamePlay()
		{
			Vibration.VibratePop();
		}
		void GameWin(int _reward)
		{
			Vibration.VibratePop();
		}
		void GameLose(int _reward)
		{
			Vibration.VibratePop();
		}

		void ButtonHaptic(Button item)
		{ 
			Vibration.VibratePop();
		}
	}
}