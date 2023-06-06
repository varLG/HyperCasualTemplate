using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template
{
	public sealed class StateGameLose : MonoBehaviour
	{

		private void OnEnable()
		{
			Debug.Log("- Game Lose: Level " + DataManager.level);
		}

	}
}
