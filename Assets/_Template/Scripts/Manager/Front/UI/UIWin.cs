using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace Template
{
	public sealed class UIWin : MonoBehaviour
	{
		[Header("Canvas")]
		[SerializeField] Canvas canvas;

		[Header("UI")]
		[SerializeField] RectTransform trWinImage;
		[SerializeField] TextMeshProUGUI textWin;

		[Header("Text")]
		[SerializeField] List<string> listWinWords;

		private void OnEnable()
		{
			EventManager.OnGameEnable += GameEnable; 
			EventManager.OnGameWin += GameWin; 
		}

		private void OnDisable()
		{
			EventManager.OnGameEnable -= GameEnable; 
			EventManager.OnGameWin -= GameWin; 
		}
		 
		void GameEnable()
		{ 
			canvas.enabled = false;
			trWinImage.anchoredPosition = new Vector2(0,trWinImage.sizeDelta.y);
			textWin.transform.localScale = Vector3.zero;
		} 
		void GameWin(int _reward)
		{
			canvas.enabled = true;
			trWinImage.DOLocalMoveY(trWinImage.localPosition.y-trWinImage.sizeDelta.y,.5f).SetEase(Ease.OutSine);

			textWin.text = listWinWords[Random.Range(0, listWinWords.Count)];
			textWin.transform.DOScale(Vector3.one,.5f).SetDelay(.25f).SetEase(Ease.OutSine);
		} 

	}
}