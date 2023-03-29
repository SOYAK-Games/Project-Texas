using System.Collections;
using System.Collections.Generic;
using Managers;
using Sirenix.OdinInspector;
using System;
using Data;
using Data.ValueObjects;
using Signals;
using Unity.Mathematics;
using UnityEngine;

namespace Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] public Rigidbody2D rigidbody;
        [SerializeField] public bool PlayerMovementInput = false;

        #endregion

        #region Private Variables

        [ShowInInspector] private MovementData _data;
        
        #endregion

        #endregion
        
        internal void GetMovementData(MovementData movementData)
        {
            _data = movementData;
        }

        private void FixedUpdate()
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