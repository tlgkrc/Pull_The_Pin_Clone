using UnityEngine;

namespace Commands
{
    public class ClearActiveLevelCommand
    {
        #region Private Variables

        private readonly GameObject _levelHolder;
        private MonoBehaviour _monoBehaviour;

        #endregion
        public ClearActiveLevelCommand(ref GameObject levelHolder,MonoBehaviour monoBehaviour)
        {
            _levelHolder = levelHolder;
            _monoBehaviour = monoBehaviour;
        }
        public void Execute()
        {
            Object.Destroy(_levelHolder.transform.GetChild(0).gameObject);
        }
    }
}