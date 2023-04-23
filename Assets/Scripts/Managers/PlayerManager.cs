using System;
using Controllers.Player;
using Data.UnityObjects;
using Data.ValueObjects;
using Signals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerWeaponController weaponController;
        [SerializeField] private PlayerAnimationController animationController;
        [ShowInInspector] private PlayerData _data;

        private void Awake()
        {
            _data = GetPlayerData();
            SendDataToControllers();

        }

        private void Update()
        {
            PlayerAnimation();
        }

        private PlayerData GetPlayerData()
        {
            return Resources.Load<CD_Player>("Data/CD_Player").Data;
        }

        private void SendDataToControllers()
        {
            movementController.GetMovementData(_data.MovementData);
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PlayerSignals.Instance.onAnimation += PlayerAnimation;
            InputSignals.Instance.onLeftMouseInput += OnLeftMouseInputTaken;
            InputSignals.Instance.onRightMouseInput += OnRightMouseInputTaken;
            InputSignals.Instance.onKeyboardInputTaken += OnKeyboardInputTaken;
            InputSignals.Instance.onKeyboardInputReleased += OnKeyboardInputReleased;
        }

        private void UnSubscribeEvents()
        {
            PlayerSignals.Instance.onAnimation -= PlayerAnimation;
            InputSignals.Instance.onLeftMouseInput -= OnLeftMouseInputTaken;
            InputSignals.Instance.onRightMouseInput -= OnRightMouseInputTaken;
            InputSignals.Instance.onKeyboardInputTaken -= OnKeyboardInputTaken;
            InputSignals.Instance.onKeyboardInputReleased -= OnKeyboardInputReleased;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void PlayerAnimation()
        {
            animationController.PlayAnimation();
        }

        private void OnLeftMouseInputTaken()
        {
            if (weaponController.PlayerHasPistol == true) // Uzak Dövüş
            {
                if (animationController.animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerPistolShoot") &&
                    Input.GetMouseButtonDown(0))
                {
                    return;
                }
                if(Input.GetMouseButtonDown(0))
                {
                    animationController.PlayerHasPistol = true;
                    animationController.PlayerAttacking = true;
                    animationController.PlayAnimation();
                    weaponController.Shoot();

                }
            }
            if (weaponController.PlayerHasPistol == false && Input.GetMouseButtonDown(0)) // Yakın Dövüş
            {
                if (animationController.animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerUnarmedAttack") &&
                    Input.GetMouseButtonDown(0))
                {
                    return;
                }
                if(Input.GetMouseButtonDown(0))
                {
                    animationController.PlayerHasPistol = false;
                    animationController.PlayerAttacking = true;
                    animationController.PlayAnimation();
                }

            }
        }

        private void OnRightMouseInputTaken()
        {
            if (weaponController.PlayerHasPistol == true) // pistol varsa pistolü at
            {
                weaponController.ThrowPistol();
                weaponController.PlayerHasPistol = false;
                animationController.PlayerHasPistol = false;
            }

            if (weaponController.PlayerHasPistol == false &&
                weaponController.IsPlayerOnTopOfPistol == true) // pistol yoksa pistolü al
            {
                weaponController.GrabPistol();
                weaponController.PlayerHasPistol = true;
                animationController.PlayerHasPistol = true;
            }
            else
            {
                return;
            }

        }

        private void OnKeyboardInputTaken()
        {
            if (weaponController.PlayerHasPistol == false)
            {
                movementController.PlayerMovementInput = true;
                animationController.PlayerHasPistol = false;
                animationController.PlayerMoving = true;

                animationController.PlayAnimation();
            }
            if (weaponController.PlayerHasPistol == true)
            {
                animationController.PlayerHasPistol = true;
                movementController.PlayerMovementInput = true;
                animationController.PlayerMoving = true;
                animationController.PlayAnimation();
            }
        }

        private void OnKeyboardInputReleased()
        {
            if (weaponController.PlayerHasPistol == false)
            {
                animationController.PlayerHasPistol = false;
                movementController.PlayerMovementInput = false;
                animationController.PlayerMoving = false;
                animationController.PlayerAttacking = false;
                animationController.PlayAnimation();
            }

            if (weaponController.PlayerHasPistol == true)
            {
                animationController.PlayerHasPistol = true;
                movementController.PlayerMovementInput = false;
                animationController.PlayerMoving = false;
                animationController.PlayerAttacking = false;
                animationController.PlayAnimation();
            }
        }
    }
}