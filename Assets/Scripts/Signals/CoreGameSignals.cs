using System;
using Enums;
using Extensions;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onUnarmedIdle = delegate { };
        public UnityAction onUnarmedMove = delegate { };
        public UnityAction onPistolMove = delegate { };
        public UnityAction onPistolShoot = delegate { };
        public UnityAction onPistolIdle = delegate { };

    }
}