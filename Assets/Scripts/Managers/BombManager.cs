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

        public void Explode()
        {
            if (!_isActivated)
            {
                _sequence = DOTween.Sequence();
                meshController.ChangeMeshColor();
                _isActivated = true;
                _sequence.Append(transform.DOScale(1.2f, 2f));
                _sequence.Insert(.5f, transform.DOShakeRotation(.8f, 2f, 4));
                _sequence.OnComplete(() =>
                {
                    meshController.gameObject.SetActive(false);
                    explodeParticle.gameObject.SetActive(true);
                    AudioSignals.Instance.onPlayExplosionSound?.Invoke();
                    _sequence.Kill();
                    if (!_sequence.IsActive())
                    {
                        Invoke(nameof(DelayDestroy),.4f);
                    }
                });
            }
        }

        private void DelayDestroy()
        {
            gameObject.SetActive(false);
        }
    }
}