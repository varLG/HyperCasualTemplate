using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template
{
	public sealed class StateGamePlay : MonoBehaviour
	{
		private void OnEnable()
		{
			Debug.Log("- Game Play: Level " + DataManager.level);
		}
	}
}
