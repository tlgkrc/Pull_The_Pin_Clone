using Signals;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip scoreSound;
        [SerializeField] private AudioClip explosionSound;
        [SerializeField] private AudioClip confettiSound;
        
        #endregion

        #region Event Subscriptions
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            AudioSignals.Instance.onPlayScoreSound += OnPlayScoreSound;
            AudioSignals.Instance.onPlayExplosionSound += OnPlayExplosionSound;
            CoreGameSignals.Instance.onLevelSuccesfull += OnLevelSuccesfull;
        }

        private void UnsubscribeEvents()
        {
            AudioSignals.Instance.onPlayScoreSound -= OnPlayScoreSound;
            AudioSignals.Instance.onPlayExplosionSound -= OnPlayExplosionSound;
            CoreGameSignals.Instance.onLevelSuccesfull -= OnLevelSuccesfull;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnPlayScoreSound()
        {
            if (!audioSource.isPlaying )
            {
                audioSource.PlayOneShot(scoreSound);
            }
        }

        private void OnPlayExplosionSound()
        {
            audioSource.Stop();
            audioSource.PlayOneShot(explosionSound);
        }

        private void OnLevelSuccesfull()
        {
            audioSource.Stop();
            audioSource.PlayOneShot(confettiSound);
        }
    }
}