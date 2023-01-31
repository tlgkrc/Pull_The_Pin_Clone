using System;
using DG.Tweening;
using Signals;
using UnityEngine;
using Random = System.Random;

namespace Managers
{
    public class PinManager : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private Transform rodTransform;

        public AnimationCurve Curve;
        
        #endregion

        #region Event Subscriptions
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PinSignals.Instance.onSelectedPin += OnSelectedPin;
        }

        private void UnsubscribeEvents()
        {
            PinSignals.Instance.onSelectedPin -= OnSelectedPin;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnSelectedPin(GameObject selectedGameobject)
        {
            
            if (selectedGameobject.transform.parent == transform)
            {
                MovePin();
            }
        }

        private void MovePin()
        {
            transform.DOLocalMove(transform.up * rodTransform.localScale.x / 5 + transform.position, 3f).
                SetSpeedBased().OnComplete(()=> DOTween.KillAll());

            // transform.DOLocalMove(transform.up * 20 + transform.position, 3f).SetSpeedBased().SetEase(Curve);
            // Curve.Evaluate(.5f);
        }
    }
}