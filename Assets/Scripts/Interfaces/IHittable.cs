using UnityEngine;

namespace Interfaces
{
    public interface IHittable
    {
        public void ReceiveHit(RaycastHit2D hit);

    }
}