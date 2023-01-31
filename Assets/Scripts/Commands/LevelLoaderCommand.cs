using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    public class LevelLoaderCommand
    {
        #region Self Variables

        private readonly GameObject _levelHolder;
        private readonly List<GameObject> _levelDatas;

        #endregion
        public LevelLoaderCommand(ref GameObject levelHolder,List<GameObject> levelDatas)
        {
            _levelHolder = levelHolder;
            _levelDatas = levelDatas;
        }
        
        public void Execute(int levelID)
        {
            Object.Instantiate(_levelDatas[levelID% _levelDatas.Count], _levelHolder.transform);
        }
    }
}