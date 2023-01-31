using System;
using System.Collections.Generic;
using Controllers;
using Controllers.UI;
using Enums;
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
        [SerializeField] private TextMeshProUGUI scoreText;
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
            // CoreGameSignals.Instance.onPlay += OnPlay;
            // CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
            // UISignals.Instance.onOpenPanel += OnOpenPanel;
            // UISignals.Instance.onClosePanel += OnClosePanel;
            // UISignals.Instance.onSetScoreText += OnSetScoreText;
            // UISignals.Instance.onSetBestScore += OnSetBestScore;

            UISignals.Instance.onUpdateCupScore += OnUpdateCupScore;
            UISignals.Instance.onSubscribeCupScore += OnSubscribeCupScore;
            UISignals.Instance.onSetLevelText += OnSetLevelText;
        }

        private void UnsubscribeEvents()
        {
            // CoreGameSignals.Instance.onPlay -= OnPlay;
            // CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            // UISignals.Instance.onOpenPanel -= OnOpenPanel;
            // UISignals.Instance.onClosePanel -= OnClosePanel;
            // UISignals.Instance.onSetScoreText -= OnSetScoreText;
            
            UISignals.Instance.onUpdateCupScore -= OnUpdateCupScore;
            UISignals.Instance.onSubscribeCupScore -= OnSubscribeCupScore;
            UISignals.Instance.onSetLevelText -= OnSetLevelText;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void Start()
        {
        }

        private void OnOpenPanel(UIPanels panelParam)
        {
            _uiChangePanelVisualityCommand.Execute(panelParam , true);
        }

        private void OnClosePanel(UIPanels panelParam)
        {
            _uiChangePanelVisualityCommand.Execute(panelParam , false);
        }

        private void OnPlay()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.LevelPanel);
        }

        private void OnNextLevel()
        {
            // UISignals.Instance.onClosePanel?.Invoke(UIPanels.LevelPanel);
            // UISignals.Instance.onOpenPanel?.Invoke(UIPanels.NextLevel);
            cupScoreController.ResetPercentage();
        }


        private void OnSetScoreText(ushort score)
        {
            scoreText.text = score.ToString();
        }

        private void OnSetBestScore(ushort best)
        {
        }

        private void OnReset()
        {
            cupScoreController.ResetPercentage();
            
        }

        public void Play()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
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