using Signals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Managers
{
    public class SaveManager : MonoBehaviour
    {
        #region Event Supcriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            SaveSignals.Instance.onSaveActiveLevel += OnSaveActiveLevel;
            SaveSignals.Instance.onGetLastLevel += OnGetLevelID;
        }

        private void UnsubscribeEvents()
        {
            SaveSignals.Instance.onSaveActiveLevel -= OnSaveActiveLevel;
            SaveSignals.Instance.onGetLastLevel -= OnGetLevelID;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnSaveActiveLevel(int levelID)
        {
            PlayerPrefs.SetInt("LevelID" ,levelID);
        }

        private int OnGetLevelID()
        {
            return PlayerPrefs.GetInt("LevelID", 0);
        }

        [Button]
        private void ResetSave()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}