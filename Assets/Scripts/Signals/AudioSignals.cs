using Extentions;
using UnityEngine.Events;

namespace Signals
{
    public class AudioSignals : MonoSingleton<AudioSignals>
    {
        public UnityAction onPlayScoreSound;
        public UnityAction onPlayExplosionSound;
    }
}