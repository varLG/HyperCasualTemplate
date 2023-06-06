using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Template
{
	public sealed class UIReward : MonoBehaviour
	{
		[Header("Canvas")]
		[SerializeField] Canvas canvas;

		[Header("Collect")]
		[SerializeField] Button btnCollect;
		[SerializeField] TextMeshProUGUI textCollect;
		[SerializeField] TextMeshProUGUI textReward;

		[Header("Margin")]
		[SerializeField] Transform trArrow;
		[SerializeField] Animation animArrow;
		[SerializeField] List<Transform> listMarginText;
		 

		[Header("Money Animation")]
		[SerializeField] Transform trMoney; 
		[SerializeField] Transform trTargetPosition;
		[SerializeField] Transform trMoneyPoolParent;
		[SerializeField] int moneyPoolSize;
		[SerializeField] List<Transform> listMoneyPool;
		Transform trRandomMoney;



		int reward, margin, marginIndexOld, marginIndexNew;
		float eulerArrow;
		bool arrowRotate = false;
		private void OnEnable()
		{
			EventManager.OnGameEnable += GameEnable;
			EventManager.OnGameWin += GameWin;
			EventManager.OnGameLose += GameLose;
		}

		private void OnDisable()
		{
			EventManager.OnGameEnable -= GameEnable;
			EventManager.OnGameWin -= GameWin;
			EventManager.OnGameLose -= GameLose;
		}

		private void Start()
		{
			btnCollect.onClick.AddListener(ClickButtonCollect);
			CreateMoneyPool();
		}
		private void Update()
		{
			if (arrowRotate)
			{
				eulerArrow = trArrow.localEulerAngles.z;
				textReward.text = (MarginCalculate(eulerArrow) * reward).ToString();
				listMarginText[marginIndexOld].localScale = Vector3.one;
				listMarginText[marginIndexNew].localScale = Vector3.one * 1.1f;
			}
		}
		void GameEnable()
		{
			canvas.enabled = false;

			animArrow.Play();
			arrowRotate = false;
			btnCollect.interactable = true;
		}

		void GameWin(int _reward)
		{
			reward = _reward;
			arrowRotate = true;

			StartCoroutine(MoneyImageAnimation());
			canvas.enabled = true; 
		}

		void GameLose(int _reward)
		{
			reward = _reward;
			arrowRotate = true;

			StartCoroutine(MoneyImageAnimation());
			canvas.enabled = true;
		}

		void ClickButtonCollect()
		{
			btnCollect.interactable = false;
			arrowRotate = false;
			animArrow.Stop();

			EventManager.GainMoney((MarginCalculate(eulerArrow) * reward), Vector3.zero);
			StartCoroutine(MoneyImageAnimation());
			EventManager.GameDisable(); 
		}

		int MarginCalculate(float _xEuler)
		{
			marginIndexOld = marginIndexNew;
			if (_xEuler > 21 && _xEuler < 60)
			{
				margin = 2;
				marginIndexNew = 0;
			}
			else if (_xEuler < 339 && _xEuler > 300)
			{
				margin = 2;
				marginIndexNew = 1;
			}
			else if (_xEuler > 6 && _xEuler < 21)
			{
				margin = 3;
				marginIndexNew = 2;
			}
			else if (_xEuler > 339 && _xEuler < 354)
			{
				margin = 3;
				marginIndexNew = 3;
			}
			else
			{
				margin = 5;
				marginIndexNew = 4;
			}

			return margin;
		}
		IEnumerator MoneyImageAnimation()
		{  
			for (int i = 0; i < listMoneyPool.Count; i++)
			{
				if (i <= 9)
				{
					int count = 10;
					int ii = i;
					float radius = 250f;


					float angle = ii * Mathf.PI * 2 / count;
					float x = Mathf.Cos(angle) * radius;
					float z = Mathf.Sin(angle) * radius;
					listMoneyPool[i].transform.localPosition = new Vector3(x, z, 0);
				}
				else
				{
					int count = 10;
					int ii = i - 10;
					float radius = 150f;


					float angle = ii * Mathf.PI * 2 / count;
					float x = Mathf.Cos(angle) * radius;
					float z = Mathf.Sin(angle) * radius;
					listMoneyPool[i].transform.localPosition = new Vector3(x, z, 0);
				}


				listMoneyPool[i].gameObject.SetActive(true);


				if (DOTween.IsTweening(listMoneyPool[i].transform))
				{
					DOTween.Kill(listMoneyPool[i].transform);
				}

				listMoneyPool[i].transform.localScale = Vector3.zero;
				listMoneyPool[i].transform.DOScale(1, 1f);
			}

			yield return new WaitForSeconds(.25f); 

			for (int i = 0; i < listMoneyPool.Count; i++)
			{
				listMoneyPool[i].transform.DOMove(trTargetPosition.position, .5f).SetEase(Ease.InOutBack).SetDelay(i * .1f);
			}

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
	}
}