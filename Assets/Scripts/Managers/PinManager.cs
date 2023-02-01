using DG.Tweening;
using Signals;
using UnityEngine;

namespace Managers
{
    public class PinManager : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private Transform rodTransform;
        [SerializeField] private AnimationCurve curve;
        
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
            transform.DOLocalMove(transform.up * rodTransform.localScale.z / 4.5f + transform.position, 2f).
                SetSpeedBased().SetEase(curve);
        }
    }
}