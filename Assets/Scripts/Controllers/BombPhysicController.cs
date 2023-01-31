using System;
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

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(BombTag) || other.CompareTag(BallTag))
            {
                manager.Explode();
            }
        }
    }
}