using System.Collections;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Signals;
using UnityEngine;

namespace Managers
{
    public class BallManager : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private bool isColored;
        [SerializeField] private BallMeshController meshController;
        [SerializeField] private BallPhysicController physicController;

        #endregion

        private void Awake()
        {
            SendDataToControllers();
            SetDefaultColor();
        }

        private ColorData GetColorData()
        {
            return Resources.Load<CD_Color>("Data/CD_Color").ColorData;
        }

        private void SendDataToControllers()
        {
            meshController.SetColorData(GetColorData());
        }


        #region Event Subscriptions
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PinSignals.Instance.onPaintBall += OnPaintBall;
        }

        private void UnsubscribeEvents()
        {
            PinSignals.Instance.onPaintBall -= OnPaintBall;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void Start()
        {
            UISignals.Instance.onSubscribeCupScore?.Invoke();
        }

        public void ReleaseBallMove()
        {
            rigidbody.constraints = RigidbodyConstraints.None;
        }

        private void SetDefaultColor()
        {
            if (isColored)
            {
                meshController.SetRandomMatColor();
            }
        }

        public void SendCurrentColorDataToControllers(Color currentColor)
        {
            physicController.SetCurrentColor(currentColor);
        }

        public bool DidPaintedBall()
        {
            return isColored;
        }

        private void OnPaintBall(Transform physicTransform,Color newColor)
        {
            if (!isColored && physicTransform.parent.gameObject.GetInstanceID() == gameObject.GetInstanceID())
            {
                isColored = true;
                physicController.SetCurrentColor(newColor);
                StartCoroutine(DelayPaint(newColor));

            }
        }

        IEnumerator DelayPaint(Color color)
        {
            yield return new WaitForEndOfFrame();
            meshController.ChangeBallColor(color);
        }
    }
}