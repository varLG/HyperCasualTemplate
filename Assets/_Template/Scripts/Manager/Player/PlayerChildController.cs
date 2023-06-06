using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template
{
	public class PlayerChildController : Singleton<PlayerChildController>
	{
		private void OnEnable()
		{
			EventManager.OnGameEnable += GameEnable;
		}

		private void OnDisable()
		{
			EventManager.OnGameEnable -= GameEnable;
		}

		void GameEnable()
		{
			transform.localPosition = Vector3.zero;
			transform.localEulerAngles = Vector3.zero;
			transform.localScale = Vector3.one;
		}
	}
}