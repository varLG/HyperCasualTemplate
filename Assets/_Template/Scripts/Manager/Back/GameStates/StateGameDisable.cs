using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template
{
	public sealed class StateGameDisable : MonoBehaviour
	{
		private void OnDisable()
		{
			Debug.Log("- Game Disable: Level " + DataManager.level);

			DOTween.Clear();
			System.GC.Collect();
		} 
	}
}
