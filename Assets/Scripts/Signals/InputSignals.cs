using Extensions;
using Keys;
using UnityEngine.Events;

namespace Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public UnityAction onInputTaken = delegate { };
        public UnityAction onInputReleased = delegate { };
        public UnityAction onMouseInputTaken = delegate { };
        public UnityAction onMouseInputReleased = delegate {  };
    }
}