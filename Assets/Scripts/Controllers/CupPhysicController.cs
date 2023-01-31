using System;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class CupPhysicController : MonoBehaviour
    {
        #region Self Variables

        private const string BallTag = "Ball";

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(BallTag))
            {
                UISignals.Instance.onUpdateCupScore?.Invoke();
                
            }
        }
    }
}