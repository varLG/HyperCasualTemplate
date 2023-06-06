using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template
{ 
	public sealed class UIFader : MonoBehaviour
	{
		[Header("Canvas")]
		[SerializeField] Canvas canvas;

		[Header("UI")]
		[SerializeField] Animation animFade;

		private void OnEnable()
		{ 
			EventManager.OnGameDisable += GameDisable;
		}
		private void OnDisable()
		{ 
			EventManager.OnGameDisable -= GameDisable;
		} 

		void GameDisable()
		{
			animFade.Play();
			canvas.enabled = true;

			StartCoroutine(CallGameEnableEvent());
		}

		IEnumerator CallGameEnableEvent()
		{
			yield return new WaitForSeconds(2);
			EventManager.GameEnable();

			yield return new WaitForSeconds(2);
			canvas.enabled = false;
			animFade.Stop();
		}
	}
}