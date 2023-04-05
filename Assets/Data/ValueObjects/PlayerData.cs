using System;

namespace Data.ValueObjects
{
    [Serializable]
    public struct PlayerData
    {
        public MovementData MovementData;
    }
    [Serializable] public struct MovementData
    {
        public float Speed;

        public MovementData(float movementSpeed)
        {
            Speed = movementSpeed;
        }
    }


}