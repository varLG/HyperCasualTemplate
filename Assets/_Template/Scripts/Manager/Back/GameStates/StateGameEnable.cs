using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template
{
	public sealed class StateGameEnable : MonoBehaviour
	{
		private void OnEnable()
		{
			Debug.Log("- Game Enable: Level " + DataManager.level); 
		}
	}
}