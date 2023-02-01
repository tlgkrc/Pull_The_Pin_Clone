using Cinemachine;
using Enums;
using UnityEngine;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Camera mainCam;
        [SerializeField] private CinemachineVirtualCamera levelCam;

        #endregion

        #region Private Variables

        private Animator _camAnimator;
        private CameraStates _cameraState;

        #endregion

        #endregion

        private void Awake()
        {
            GetReferences();
            SetBackgroundColor();
        }

        private void GetReferences()
        {
            _camAnimator = GetComponent<Animator>();
        }

        private void SetCameraStates()
        {
            if (_cameraState == CameraStates.LevelCam)
            {
                _camAnimator.Play(CameraStates.LevelCam.ToString());
            }
        }

        private void OnSetCameraState(CameraStates cameraState)
        {
            _cameraState = cameraState;
            SetCameraStates();
        }
        
        private void OnReset()
        {
            _cameraState = CameraStates.LevelCam;
            levelCam.Follow = null; 
            levelCam.LookAt = null;
        }

        private void SetBackgroundColor()
        {
            var newColor = new Color32(207, 211, 204, 255);
            mainCam.backgroundColor = newColor;
        }
    }
}