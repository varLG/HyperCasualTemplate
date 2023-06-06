using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using Unity.VisualScripting;

namespace Template
{
	public sealed class UIGame : MonoBehaviour
	{
		[Header("Canvas")]
		[SerializeField] Canvas canvas;

		[Header("Text Areas")]
		[SerializeField] TextMeshProUGUI textLevel;
		[SerializeField] TextMeshProUGUI textMoney;

		[Header("UI")]
		[SerializeField] Button btnSettings;
		[SerializeField] Transform trLevel;

		[Header("Money Animation")]
		[SerializeField] Transform trMoney;
		[SerializeField] Transform trMoneyPoolParent;
		[SerializeField] int moneyPoolSize;
		[SerializeField] List<Transform> listMoneyPool;
		Transform trRandomMoney;

		private void OnEnable()
		{
			EventManager.OnGameEnable += GameEnable;
			EventManager.OnGamePlay += GamePlay;
			EventManager.OnGameWin += GameWin;
			EventManager.OnGameLose += GameLose;
			EventManager.OnGameDisable += GameDisable;
			EventManager.OnGainMoney += GainMoney;
		}

		private void OnDisable()
		{
			EventManager.OnGameEnable -= GameEnable;
			EventManager.OnGamePlay -= GamePlay;
			EventManager.OnGameWin -= GameWin;
			EventManager.OnGameLose -= GameLose;
			EventManager.OnGameDisable -= GameDisable;
			EventManager.OnGainMoney -= GainMoney;
		}

		private void Start()
		{
			btnSettings.onClick.AddListener(ClickSettingsButton);
			CreateMoneyPool();
		}
		void GameEnable()
		{
			LoadUI();
		}
		void GamePlay()
		{
			trLevel.DOScale(Vector3.zero, .5f).SetEase(Ease.InSine);
		}
		void GameWin(int _reward)
		{
			trLevel.DOScale(Vector3.one, .5f).SetEase(Ease.InSine);
			StartCoroutine(MoneyTextAnimation());
		}
		void GameLose(int _reward)
		{
			trLevel.DOScale(Vector3.one, .5f).SetEase(Ease.InSine);
			StartCoroutine(MoneyTextAnimation());
		}
		void GameDisable()
		{
		}
		void GainMoney(int _reward, Vector3 _worldPos)
		{
			StartCoroutine(MoneyTextAnimation());
			MoneyImageAnimation(_worldPos);
		}

		void LoadUI()
		{
			canvas.enabled = true;

			textLevel.text = "Level " + DataManager.level;
			textLevel.transform.localScale = Vector3.one;

			textMoney.text = DataManager.money.ToString();
			textMoney.transform.localScale = Vector3.one;
		}

		void ClickSettingsButton()
		{
			UISettings.Instance.OpenCanvas();
		}

		IEnumerator MoneyTextAnimation()
		{
			yield return new WaitForNextFrameUnit();
			if (DataManager.money > TextMoneyToInt())
			{
				textMoney.text = (TextMoneyToInt() + 1).ToString();
			}
			else if (DataManager.money < TextMoneyToInt())
			{
				textMoney.text = (TextMoneyToInt() - 1).ToString();

			}
			else
				yield break;

			StartCoroutine(MoneyTextAnimation());
		}

		int TextMoneyToInt()
		{
			return Convert.ToInt16(textMoney.text);
		}
		void CreateMoneyPool()
		{
			for (int i = 0; i < moneyPoolSize; i++)
			{
				trRandomMoney = Instantiate(trMoney.gameObject, trMoneyPoolParent).transform;
				listMoneyPool.Add(trRandomMoney);
				trRandomMoney.gameObject.SetActive(false);
			}
		}
		void MoneyImageAnimation(Vector3 _worldPos)
		{
			if (GameManager.Instance.gameActive)
			{
				trRandomMoney = listMoneyPool[0];

				if (!DOTween.IsTweening(trRandomMoney.transform))
				{
					trRandomMoney.gameObject.SetActive(true);
					listMoneyPool.RemoveAt(0);
					listMoneyPool.Add(trRandomMoney);

					trRandomMoney.transform.position = Camera.main.WorldToScreenPoint(_worldPos);

					trRandomMoney.transform.DOMove(trMoney.transform.position, 1f).SetDelay(.1f).SetEase(Ease.InOutBack);
				}
			}
		}
	}
}
