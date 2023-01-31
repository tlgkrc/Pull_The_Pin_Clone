using Controllers;
using DG.Tweening;
using UnityEngine;

namespace Managers
{
    public class BombManager : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private BombMeshController meshController;
        [SerializeField] private BombPhysicController physicController;
        [SerializeField] private ParticleSystem explodeParticle;
        

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
            transform.DOScale(1.2f, 2f);
            meshController.ChangeMeshColor();

        }
    }
}