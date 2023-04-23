using Extensions;
using Keys;
using UnityEngine.Events;

namespace Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
<<<<<<< HEAD

=======
        public UnityAction<InputParams> keyboardinput = delegate {  };
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
        public UnityAction onInputTaken = delegate { };
        public UnityAction onInputReleased = delegate { };
        public UnityAction onLeftMouseInput = delegate { };
        public UnityAction onRightMouseInput = delegate {  };
    }
}