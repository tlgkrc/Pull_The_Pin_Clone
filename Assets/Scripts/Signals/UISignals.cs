using Enums;
using Extentions;
using UnityEngine.Events;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<UIPanels> onOpenPanel = delegate { };
        public UnityAction<UIPanels> onClosePanel = delegate { };
        public UnityAction<ushort> onSetBestScore = delegate {  };
        public UnityAction<ushort> onSetScoreText = delegate { };
        public UnityAction onUpdateCupScore;
        public UnityAction onSubscribeCupScore;
        public UnityAction<ushort> onSetLevelText;
    }
}