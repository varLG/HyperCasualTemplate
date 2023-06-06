using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using UnityEngine.UI; 

namespace Template
{
	public sealed class UISettings : Singleton<UISettings>
	{
		[Header("Canvas")]
		[SerializeField] Canvas canvas;

		[Header("Interactable")]
		[SerializeField] Button btnClose;
		[SerializeField] Slider sliderSound;
		[SerializeField] Slider sliderHaptic;


		private void Start()
		{
			LoadUI();

			btnClose.onClick.AddListener(CloseCanvas);
			sliderSound.onValueChanged.AddListener(ChangeSliderSound);
			sliderHaptic.onValueChanged.AddListener(ChangeSliderHaptic);
		}
		public void OpenCanvas()
		{
			canvas.enabled = true;
		}

		void CloseCanvas()
		{
			canvas.enabled = false;
		}

		void ChangeSliderSound(float _value)
		{

			if (_value == 0)
			{
				DataManager.sound = true;
			}
			else
			{
				DataManager.sound = false;
			}
		}

		void ChangeSliderHaptic(float _value)
		{
			if (_value == 0)
			{
				DataManager.haptic = true;
			}
			else
			{
				DataManager.haptic = false;
			}
		}

		void LoadUI()
		{
			canvas.enabled = false;

			if (DataManager.sound)
				sliderSound.value = 0;
			else
				sliderSound.value = 1;



			if (DataManager.haptic)
				sliderHaptic.value = 0;
			else
				sliderHaptic.value = 1;
		}
	}
}