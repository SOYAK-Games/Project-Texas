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
                LeftMouseInputTaken();
            }

            if (Input.GetMouseButtonDown(1))
            {
                RightMouseInputTaken();
            }
        }
        
        private void OnInputTaken()
        {
            InputSignals.Instance.onInputTaken?.Invoke();
        }

        private void OnInputReleased()
        {
            InputSignals.Instance.onInputReleased?.Invoke();
        }

        private void LeftMouseInputTaken()
        {
            InputSignals.Instance.onLeftMouseInput?.Invoke();
        }
        private void RightMouseInputTaken()
        {
            InputSignals.Instance.onRightMouseInput?.Invoke();
        }
    }
}
