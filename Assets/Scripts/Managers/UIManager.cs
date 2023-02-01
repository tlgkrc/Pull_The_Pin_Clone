using System.Collections.Generic;
using Commands;
using Controllers;
using Signals;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private List<GameObject> panels;
        [SerializeField] private UICupScoreController cupScoreController;
        [SerializeField] private TextMeshProUGUI levelText;

        #endregion

        #region Private Variables
        
        private UIChangePanelVisualityCommand _uiChangePanelVisualityCommand;
        
        #endregion

        #endregion

        private void Awake()
        {
            _uiChangePanelVisualityCommand = new UIChangePanelVisualityCommand(ref panels);
        }

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
            UISignals.Instance.onUpdateCupScore += OnUpdateCupScore;
            UISignals.Instance.onSubscribeCupScore += OnSubscribeCupScore;
            UISignals.Instance.onSetLevelText += OnSetLevelText;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            UISignals.Instance.onUpdateCupScore -= OnUpdateCupScore;
            UISignals.Instance.onSubscribeCupScore -= OnSubscribeCupScore;
            UISignals.Instance.onSetLevelText -= OnSetLevelText;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnNextLevel()
        {
            cupScoreController.ResetPercentage();
        }
        
        private void OnUpdateCupScore()
        {
            cupScoreController.IncreasePercentage();
        }

        private void OnSubscribeCupScore()
        {
            cupScoreController.SetTotalBallNumber();
        }

        private void OnSetLevelText(ushort level)
        {
            levelText.text = "LEVEL " + level.ToString();
        }
    }
}