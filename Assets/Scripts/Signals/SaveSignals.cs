using System;
using Extentions;
using UnityEngine.Events;

namespace Signals
{
    public class SaveSignals : MonoSingleton<SaveSignals>
    {
        public UnityAction<int> onSaveActiveLevel;
        public Func<int> onGetLastLevel = delegate { return 0;};
    }
}