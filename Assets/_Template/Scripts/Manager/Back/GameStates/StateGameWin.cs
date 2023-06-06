using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template
{
	public sealed class StateGameWin : MonoBehaviour
	{
		private void OnEnable()
		{
			Debug.Log("- Game Win: Level " + DataManager.level);
		}
	}
}
