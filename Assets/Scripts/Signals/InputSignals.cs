using Extensions;
using Keys;
using UnityEngine.Events;

namespace Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public UnityAction<InputParams> keyboardinput = delegate {  };
        public UnityAction onInputTaken = delegate { };
        public UnityAction onInputReleased = delegate { };
        public UnityAction onLeftMouseInput = delegate { };
        public UnityAction onRightMouseInput = delegate {  };
    }
}