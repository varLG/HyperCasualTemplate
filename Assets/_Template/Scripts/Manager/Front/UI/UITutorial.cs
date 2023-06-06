using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template
{
	public class UITutorial : MonoBehaviour
	{
		[Header("Canvas")]
		[SerializeField] Canvas canvas;

		[Header("Animation")]
		[SerializeField] Animation animFirstTutorial;

		private void OnEnable()
		{ 
			EventManager.OnGamePlay += GamePlay;
		}

		private void OnDisable()
		{ 
			EventManager.OnGamePlay -= GamePlay;
		}

		void Start()
		{
			FirstTutorial();
		}

		void GamePlay()
		{
			canvas.enabled = false;
			animFirstTutorial.Stop();
		}

		void FirstTutorial()
		{
			if(PlayerPrefs.GetInt("first_tutorial")==0)
			{
				canvas.enabled = true;
				animFirstTutorial.Play();

				PlayerPrefs.SetInt("first_tutorial",1);
			}
		}
	}
}