using System;
using DG.Tweening;
using Managers;
using Signals;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class UICupScoreController : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private UIManager manager;
        [SerializeField] private TextMeshProUGUI percentageText;
        [SerializeField] private GameObject trueSignGameObject;

        private float _collectedBall;
        private float _totalBall;
        private const string PercentageSymbol = "%";

        #endregion

        private void Awake()
        {
            WritePercentage();
        }

        public void IncreasePercentage()
        {
            _collectedBall++;
            WritePercentage();
            PinSignals.Instance.onWeightPassedBorder?.Invoke(1/_totalBall);

            if (Math.Abs(_collectedBall - _totalBall) < 0.01f)
            {
                CoreGameSignals.Instance.onLevelSuccesfull?.Invoke();
                percentageText.gameObject.transform.DOScale(Vector3.zero, .05f);
                trueSignGameObject.transform.DOScale(Vector3.one, .5f);
            }
        }

        public void ResetPercentage()
        {
            _collectedBall = 0;
            _totalBall = 0;
            percentageText.gameObject.transform.DOScale(Vector3.one, .05f);
            trueSignGameObject.transform.DOScale(Vector3.zero, .05f);
        }

        public void SetTotalBallNumber()
        {
            _totalBall += 1;
            WritePercentage();
        }
        private void WritePercentage()
        {
            if (_totalBall == 0) return;
            var newScore = _collectedBall / _totalBall;
            percentageText.text = ((int)(newScore*100)) + PercentageSymbol;
        }
    }
}