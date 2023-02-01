using Managers;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class BallPhysicController : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private BallManager manager;

        private const string CupEntryTag = "CupEntry";
        private const string BallTag = "Ball";
        private const string BombTag = "BombParticle";
        private bool _didEnterCup;
        private Color _currentColor;

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(CupEntryTag) && !_didEnterCup)
            {
                manager.ReleaseBallMove();
                _didEnterCup = true;
            }
            
            if (other.CompareTag(BallTag) && manager.DidPaintedBall() )
            {
                PinSignals.Instance.onPaintBall?.Invoke(other.transform,_currentColor);
            }

            if (other.CompareTag(BombTag))
            {
                manager.gameObject.SetActive(false);
            }
        }

        public void SetCurrentColor(Color currentColor)
        {
            _currentColor = currentColor;
        }
    }
}