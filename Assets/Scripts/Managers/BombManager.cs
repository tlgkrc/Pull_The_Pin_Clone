using Controllers;
using DG.Tweening;
using Signals;
using UnityEngine;

namespace Managers
{
    public class BombManager : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private BombMeshController meshController;
        [SerializeField] private BombPhysicController physicController;
        [SerializeField] private ParticleSystem explodeParticle;

        private bool _isActivated;
        private Sequence _sequence;
        
        #endregion
        
        #region Event Subscriptions
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
        }

        private void UnsubscribeEvents()
        {
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        public void Explode()
        {
            if (!_isActivated)
            {
                meshController.ChangeMeshColor();
                _isActivated = true;
                _sequence.Append(transform.DOScale(1.2f, 3f).OnComplete(() =>
                    {
                        AudioSignals.Instance.onPlayExplosionSound?.Invoke();
                        _sequence.Kill();
                        meshController.gameObject.SetActive(false);
                        physicController.gameObject.SetActive(false);
                        explodeParticle.gameObject.SetActive(true);
                        
                    }
                ));
                _sequence.Insert(.4f, transform.DOShakeRotation(.2f,1f, 3));
            }
        }
    }
}