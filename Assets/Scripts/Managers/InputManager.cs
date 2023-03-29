using System;
using System.Collections.Generic;
using Controllers.Player;
using Data.UnityObjects;
using Data.ValueObjects;
using Keys;
using Signals;
using Sirenix.OdinInspector;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        #region Private Variables
        [Space] [ShowInInspector] public static bool KeyboardInput;
        [Space] [ShowInInspector] public static bool MouseInput;
        
        //[ShowInInspector] private InputData _data;

        #endregion
        

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.S) |
                Input.GetKeyDown(KeyCode.D))
            {
                OnInputTaken();
            }

            if (Input.GetKey(KeyCode.D) != true && Input.GetKey(KeyCode.W) != true && Input.GetKey(KeyCode.S) != true &&
                Input.GetKey(KeyCode.A) != true)
            {
                OnInputReleased();
            }
            if (Input.GetMouseButtonDown(0))
            {
                MouseInputTaken();
            }

            if (Input.GetMouseButtonUp(0))
            {
                MouseInputReleased();
            }

        }

        private void OnMouseInput()
        {
            if(Input.GetMouseButtonDown(0) == true)
            {
                MouseInput = true;
            }
            else if (Input.GetMouseButton(0) != true)
            {
                MouseInput = false;
            }
        }
        private void OnInputTaken()
        {
            KeyboardInput = true;
            InputSignals.Instance.onInputTaken?.Invoke();
        }

        private void OnInputReleased()
        {   
            KeyboardInput = false;
            InputSignals.Instance.onInputReleased?.Invoke();
        }

        private void MouseInputTaken()
        {
            MouseInput = true;
            InputSignals.Instance.onMouseInputTaken?.Invoke();
        }
        private void MouseInputReleased()
        {
            MouseInput = false;
            InputSignals.Instance.onMouseInputReleased?.Invoke();
        }
    }
}
