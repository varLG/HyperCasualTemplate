using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Template
{
	public sealed class SoundManager : Singleton<SoundManager>
	{
		AudioSource audioSource;

		[SerializeField] AudioClip audioWin;
		[SerializeField] AudioClip audioMoney;
		[SerializeField] AudioClip audioButton;
		

		private void OnEnable()
		{
			EventManager.OnGameWin += GameWin;
			EventManager.OnGainMoney += GainMoney;
		}

		private void OnDisable()
		{
			EventManager.OnGameWin -= GameWin;
			EventManager.OnGainMoney -= GainMoney;
		}

		private void Awake()
		{
			audioSource=GetComponent<AudioSource>();

			foreach (Button item in Resources.FindObjectsOfTypeAll<Button>())
			{
				item.onClick.AddListener(() => ButtonSound(item));
			}
		}
		void GameWin(int _reward)
		{
			audioSource.PlayOneShot(audioWin);
		}

		void GainMoney(int _gainedMoney, Vector3 _worldPos)
		{
			audioSource.PlayOneShot(audioMoney);
		}

		void ButtonSound(Button item)
		{
			audioSource.PlayOneShot(audioButton);
		}

	}
}