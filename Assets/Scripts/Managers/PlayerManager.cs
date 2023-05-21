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
            InputSignals.Instance.onLeftMouseInputReleased += OnLeftMouseInputReleased;
            InputSignals.Instance.onKeyboardInputTaken += OnKeyboardInputTaken;
            InputSignals.Instance.onKeyboardInputReleased += OnKeyboardInputReleased;
        }

        private void UnSubscribeEvents()
        {
            PlayerSignals.Instance.onAnimation -= PlayerAnimation;
            InputSignals.Instance.onLeftMouseInput -= OnLeftMouseInputTaken;
            InputSignals.Instance.onLeftMouseInputReleased -= OnLeftMouseInputReleased;
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
                animationController.animator.ResetTrigger("UnarmedIdle");
                animationController.animator.SetTrigger("PlayerShoot");
                animationController.PlayAnimation();
                weaponController.Shoot();

            }
            if (weaponController.PlayerHasPistol == false) // Yakın Dövüş
            {
                if (animationController.animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerUnarmedAttack") &&
                    Input.GetMouseButtonDown(0))
                {
                    return;
                }
                animationController.animator.ResetTrigger("UnarmedIdle");
                animationController.animator.SetTrigger("PlayerAttack");
                animationController.PlayAnimation();
            }
        }



        private void OnLeftMouseInputReleased()
        {
            if (weaponController.PlayerHasPistol == true)
            {
                animationController.PlayAnimation();
                animationController.animator.ResetTrigger("PlayerShoot");
                animationController.animator.SetTrigger("PistolIdle");

            }
            if (weaponController.PlayerHasPistol == false)
            {
                animationController.PlayAnimation();
                animationController.animator.ResetTrigger("PlayerAttack");
                animationController.animator.SetTrigger("UnarmedIdle");
            }
        }

        private void OnRightMouseInputTaken()
        {
            if (weaponController.PlayerHasPistol == true) // pistol varsa pistolü at
            {
                weaponController.ThrowPistol();
                weaponController.PlayerHasPistol = false;
            }

            if (weaponController.PlayerHasPistol == false &&
                weaponController.IsPlayerOnTopOfPistol == true) // pistol yoksa pistolü al
            {
                weaponController.GrabPistol();
                weaponController.PlayerHasPistol = true;
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
                animationController.PlayerMoving = true;
                animationController.animator.SetTrigger("UnarmedMove");
                animationController.animator.ResetTrigger("UnarmedIdle");
                animationController.PlayAnimation();
            }
            if (weaponController.PlayerHasPistol == true)
            {
                movementController.PlayerMovementInput = true; 
                animationController.PlayerMoving = true;
                animationController.animator.SetTrigger("PistolMove");
                animationController.animator.ResetTrigger("PistolIdle");
                animationController.PlayAnimation();
            }
        }

        private void OnKeyboardInputReleased()
        {
            if (weaponController.PlayerHasPistol == false)
            {
                movementController.PlayerMovementInput = false;
                animationController.animator.ResetTrigger("UnarmedMove");
                animationController.animator.SetTrigger("UnarmedIdle");
                animationController.PlayAnimation();
            }

            if (weaponController.PlayerHasPistol == true)
            {
                movementController.PlayerMovementInput = false;
                animationController.animator.ResetTrigger("PistolMove");
                animationController.animator.SetTrigger("PistolIdle");
                animationController.PlayAnimation();
            }
        }
    }

}