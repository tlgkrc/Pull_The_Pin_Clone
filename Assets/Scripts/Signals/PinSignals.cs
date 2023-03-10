using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class PinSignals : MonoSingleton<PinSignals>
    {
        public UnityAction<GameObject> onSelectedPin;
        public UnityAction<float> onWeightPassedBorder;
        public UnityAction<Transform,Color> onPaintBall;
    }
}