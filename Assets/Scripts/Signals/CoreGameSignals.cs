using System;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onPlay = delegate {  };
        public UnityAction onReset = delegate {  };
        public UnityAction onNextLevel = delegate {  };
        public UnityAction onLevelFailed = delegate {  };
        public UnityAction onLevelSuccesfull;
        public UnityAction onClearActiveLevel;
        public UnityAction onLevelInitialize;
    }
}