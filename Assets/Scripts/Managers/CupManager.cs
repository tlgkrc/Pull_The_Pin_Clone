using DG.Tweening;
using Signals;
using UnityEngine;

namespace Managers
{
    public class CupManager : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private ParticleSystem confettiPS;

        private const ushort TotalReplacementDistance = 20;

        #endregion
        
        #region Event Subscriptions
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PinSignals.Instance.onWeightPassedBorder += OnWeightPassedBorder;
            CoreGameSignals.Instance.onLevelSuccesfull += OnLevelSuccesfull;
        }

        private void UnsubscribeEvents()
        {
            PinSignals.Instance.onWeightPassedBorder -= OnWeightPassedBorder;
            CoreGameSignals.Instance.onLevelSuccesfull -= OnLevelSuccesfull;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnWeightPassedBorder(float replacementRatio)
        {
            transform.DOMove( Vector3.down*TotalReplacementDistance*replacementRatio + transform.position, 1f);
        }

        private void OnLevelSuccesfull()
        {
            confettiPS.gameObject.SetActive(true);
        }
    }
}