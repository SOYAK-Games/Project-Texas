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
        //[ShowInInspector] private InputData _data;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W) | Input.GetKeyDown(KeyCode.A) | Input.GetKeyDown(KeyCode.S) |
                Input.GetKeyDown(KeyCode.D))
            {
                OnKeyboardInputTaken();
            }
            if (Input.GetKey(KeyCode.D) != true && Input.GetKey(KeyCode.W) != true && Input.GetKey(KeyCode.S) != true &&
                Input.GetKey(KeyCode.A) != true)
            {
                OnKeyboardInputReleased();
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
        
        private void OnKeyboardInputTaken()
        {
            InputSignals.Instance.onKeyboardInputTaken?.Invoke();
        }
        private void OnKeyboardInputReleased()
        {
            InputSignals.Instance.onKeyboardInputReleased?.Invoke();
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
