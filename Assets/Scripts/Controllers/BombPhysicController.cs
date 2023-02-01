using Managers;
using UnityEngine;

namespace Controllers
{
    public class BombPhysicController : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private BombManager manager;
        
        private const string BombTag = "Bomb";
        private const string BallTag = "Ball";
        private bool _isActivated;

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (_isActivated)
            {
                return;
            }
            if (other.CompareTag(BombTag) || other.CompareTag(BallTag))
            {
                manager.Explode();
                _isActivated = true;
            }
        }
    }
}