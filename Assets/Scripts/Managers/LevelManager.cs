using Commands;
using Data.UnityObject;
using Data.ValueObject;
using Signals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        [Header("Data")] public LevelData LevelsData;

        #endregion

        #region Serialized Variables

        [Space] [SerializeField] private GameObject levelHolder;
        [SerializeField] private LevelLoaderCommand levelLoader;

        #endregion

        #region Private Variables

        [ShowInInspector] private int _levelID;
        private ClearActiveLevelCommand _clearActiveLevelCommand;
        private LevelLoaderCommand _levelLoaderCommand;

        #endregion

        #endregion

        private void Awake()
        {
            
            LevelsData = GetLevelData();
            _levelLoaderCommand = new LevelLoaderCommand(ref levelHolder, LevelsData.LevelDatas);
            _clearActiveLevelCommand = new ClearActiveLevelCommand(ref levelHolder, this);
        }

        private int GetActiveLevel()
        {
            if (SaveSignals.Instance.onGetLastLevel?.Invoke() != null) 
            {
                return (int)SaveSignals.Instance.onGetLastLevel?.Invoke();
            }
            else
            {
                return 0;
            }
        }

        private LevelData GetLevelData()
        {
            var newLevelData = _levelID % Resources.Load<CD_Level>("Data/CD_Level").LevelData.LevelDatas.Count;
            return Resources.Load<CD_Level>("Data/CD_Level").LevelData;
        }

        #region Event Subscription

        private void OnEnable()
        {
           
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize += OnInitializeLevel;
            CoreGameSignals.Instance.onClearActiveLevel += _clearActiveLevelCommand.Execute;
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;

            CoreGameSignals.Instance.onLevelSuccesfull += OnLevelSuccesfull;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize -= OnInitializeLevel;
            CoreGameSignals.Instance.onClearActiveLevel -= _clearActiveLevelCommand.Execute;
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.onLevelSuccesfull -= OnLevelSuccesfull;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void Start()
        {
            _levelID = GetActiveLevel();
            UISignals.Instance.onSetLevelText?.Invoke((ushort)(_levelID+1));
            OnInitializeLevel();
        }

        private void OnInitializeLevel()
        {
            var newLevelData = _levelID % Resources.Load<CD_Level>("Data/CD_Level").LevelData.LevelDatas.Count;
            _levelLoaderCommand.Execute(_levelID);
        }

        private void OnNextLevel()
        {
            _levelID++;

            CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
            SaveSignals.Instance.onSaveActiveLevel?.Invoke(_levelID);
            CoreGameSignals.Instance.onLevelInitialize?.Invoke();
        }

        private void OnRestartLevel()
        {

        }

        private void OnLevelSuccesfull()
        {
            Invoke(nameof(NextLevel),2);
        }

        private void NextLevel()
        {
            CoreGameSignals.Instance.onNextLevel?.Invoke();
            UISignals.Instance.onSetLevelText?.Invoke((ushort)(_levelID + 1));
        }
    }
}