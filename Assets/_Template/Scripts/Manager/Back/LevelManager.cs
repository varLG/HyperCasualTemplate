using Pixelplacement;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Template
{
	public sealed class LevelManager : Singleton<LevelManager>
	{

		GameObject levelObject;
		int levelCount;
		const string levelPath = "Levels/Level_";

		[Header("Move Level Prefabs to \"Resources/Levels\" folder!\nBecareful to name of prefabs and level numbers \n	(Level_0 to Level_x)")]
		public Transform garbageObject;
		int garbageCount;



		private void OnEnable()
		{
			EventManager.OnGameEnable += GameEnable;
		}

		private void OnDisable()
		{
			EventManager.OnGameEnable -= GameEnable;
		}

		private void Awake()
		{
			levelCount = LevelCount();
		}

		void GameEnable()
		{
			ClearGarbage();

			levelObject = Resources.Load<GameObject>(levelPath + ((DataManager.level) % levelCount));
			Instantiate(levelObject, Vector3.zero, Quaternion.identity, garbageObject);
		}
		void ClearGarbage()
		{
			garbageCount = garbageObject.childCount;
			for (int i = 0; i < garbageCount; i++)
			{
				Destroy(garbageObject.GetChild(0).gameObject);
			}

			Resources.UnloadUnusedAssets();
		}

		int LevelCount()
		{
			int i = 0;
			while (Resources.Load<GameObject>(levelPath + i) != null)
			{
				i++;
			}

			return i;
		}
	}
}