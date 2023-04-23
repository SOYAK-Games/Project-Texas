using Sirenix.OdinInspector;
using Data.ValueObjects;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] public Rigidbody2D rigidbody;
        [SerializeField] public bool PlayerMovementInput = false;
        [ShowInInspector] private MovementData _data;

        internal void GetMovementData(MovementData movementData)
        {
            _data = movementData;
        }

        private void LateUpdate()
        {
            LookAtMouse();
            if (PlayerMovementInput == true)
            {
                MovePlayer();
            }
            if (PlayerMovementInput == false)
            {
                StopPlayer();
            }
        }
        
        private void MovePlayer()
        {
            var currentposition = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            rigidbody.velocity = currentposition.normalized * _data.Speed;
        }
        private void StopPlayer()
        {
            rigidbody.velocity = Vector3.zero;
        }
        private void LookAtMouse()
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.right = mousePos - new Vector2(transform.position.x, transform.position.y);
        }
        
    }
}