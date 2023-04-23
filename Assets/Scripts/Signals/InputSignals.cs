using Extensions;
using Keys;
using UnityEngine.Events;

namespace Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public UnityAction onKeyboardInputTaken = delegate { };
        public UnityAction onKeyboardInputReleased = delegate { };
        public UnityAction onLeftMouseInput = delegate { };
        public UnityAction onRightMouseInput = delegate {  };
    }
}