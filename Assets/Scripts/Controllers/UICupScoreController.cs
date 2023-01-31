using System;
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
            }
        }

        public void ResetPercentage()
        {
            _collectedBall = 0;
            _totalBall = 0;
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