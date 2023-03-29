using System;
using Unity.Mathematics;
using UnityEngine;

namespace Data.ValueObjects
{
    [Serializable] public struct InputData
    {
        public bool W,A,S,D;


        public InputData(bool w,bool a,bool s,bool d)
        {
            W = w;
            A = a;
            S = s;
            D = d;
        }
    }
}