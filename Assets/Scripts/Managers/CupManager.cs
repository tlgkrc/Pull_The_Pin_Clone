using DG.Tweening;
using Signals;
using UnityEngine;

namespace Managers
{
    public class CupManager : MonoBehaviour
    {
        #region Self Variables

        

        #endregion
        
        #region Event Subscriptions
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PinSignals.Instance.onWeightPassedBorder += OnWeightPassedBorder;
        }

        private void UnsubscribeEvents()
        {
            PinSignals.Instance.onWeightPassedBorder -= OnWeightPassedBorder;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnWeightPassedBorder()
        {
            //transform.DOMoveY(2f, .5f).SetEase(Ease.InOutElastic);  
        }
    }
}