using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template
{
	public sealed class UILose : MonoBehaviour
	{
		[Header("Canvas")]
		[SerializeField] Canvas canvas;

		[Header("UI")]
		[SerializeField] RectTransform trLoseImage;


		private void OnEnable()
		{
			EventManager.OnGameEnable += GameEnable;
			EventManager.OnGameLose += GameLose;
		}

		private void OnDisable()
		{
			EventManager.OnGameEnable -= GameEnable;
			EventManager.OnGameLose -= GameLose;
		}

		void GameEnable()
		{
			canvas.enabled = false;
			trLoseImage.anchoredPosition = new Vector2(0, trLoseImage.sizeDelta.y); 
		}
		void GameLose(int _reward)
		{
			canvas.enabled = true;
			trLoseImage.DOLocalMoveY(trLoseImage.localPosition.y - trLoseImage.sizeDelta.y, .5f).SetEase(Ease.OutSine); 
		}
	}
}