using Controllers;
using Controllers.Player;
using Data;
using Data.UnityObjects;
using Data.ValueObjects;
using Signals;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;
using Update = Unity.VisualScripting.Update;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerWeaponController weaponController;
        [SerializeField] private PlayerAnimationController animationController;
        [SerializeField] private MeleeAttackController meleeController;
        [ShowInInspector] private PlayerData _data;
        
        private void Awake()
        {
            _data = GetPlayerData();
            SendDataToControllers();
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
            CoreGameSignals.Instance.onUnarmedMove += OnUnarmedMove;
            CoreGameSignals.Instance.onUnarmedIdle += OnUnarmedIdle;
            CoreGameSignals.Instance.onPistolShoot += OnPistolShoot;
            CoreGameSignals.Instance.onPistolIdle += OnPistolIdle;
            CoreGameSignals.Instance.onPistolMove += OnPistolMove;
            CoreGameSignals.Instance.onUnarmedAttack += OnUnarmedAttack;
            InputSignals.Instance.onLeftMouseInput += OnLeftMouseInputTaken;
            InputSignals.Instance.onRightMouseInput += OnRightMouseInputTaken;
            InputSignals.Instance.onInputTaken += OnInputTaken;
            InputSignals.Instance.onInputReleased += OnInputReleased;
        }
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onUnarmedMove -= OnUnarmedMove;
            CoreGameSignals.Instance.onUnarmedIdle -= OnUnarmedIdle;
            CoreGameSignals.Instance.onPistolShoot -= OnPistolShoot;
            CoreGameSignals.Instance.onPistolIdle -= OnPistolIdle;
            CoreGameSignals.Instance.onPistolMove -= OnPistolMove;
            CoreGameSignals.Instance.onUnarmedAttack -= OnUnarmedAttack;
            InputSignals.Instance.onLeftMouseInput -= OnLeftMouseInputTaken;
            InputSignals.Instance.onRightMouseInput -= OnRightMouseInputTaken;
            InputSignals.Instance.onInputTaken -= OnInputTaken;
            InputSignals.Instance.onInputReleased -= OnInputReleased;
        }
        private void OnDisable()
        {
            UnSubscribeEvents();
        }
        private void OnUnarmedMove()
        {
            animationController.PlayPlayerUnarmedMoving();
        }
        private void OnUnarmedIdle()
        {
            animationController.PlayPlayerUnarmedIdle();
        }
        private void OnPistolShoot()
        {
            animationController.PlayPlayerShooting();
        }
        private void OnPistolIdle()
        {
            animationController.PlayPlayerPistolIdle();
        }
        private void OnPistolMove()
        {
            animationController.PlayPlayerPistolMoving();
        }
        private void OnUnarmedAttack()
        {
            animationController.PlayPlayerUnarmedAttack();
        }
        private void OnLeftMouseInputTaken()
        {
            if (weaponController.PlayerHasPistol == true) // Uzak Dövüş
            {
                if (animationController.Animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerPistolShoot") && Input.GetMouseButtonDown(0))
                {
                    return;
                }
                else
                {
                    weaponController.Shoot();
                    animationController.PlayPlayerShooting();
                }
            }

            if (weaponController.PlayerHasPistol == false && Input.GetMouseButtonDown(0)) // Yakın Dövüş
            {
                if (animationController.Animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerUnarmedAttack") && Input.GetMouseButtonDown(0))
                {
                    return;
                }
                else
                {
                    animationController.PlayPlayerUnarmedAttack();   
                }

            }
        }

        private void OnRightMouseInputTaken()
        {
            if (weaponController.PlayerHasPistol==true) // pistol yoksa pistolü al
            {
                weaponController.ThrowPistol();
            }
            else
            {
                return;
            }

        }
        private void OnInputTaken()
        {
            if (weaponController.PlayerHasPistol == false)
            {
                movementController.PlayerMovementInput = true;
                animationController.PlayPlayerUnarmedMoving();
            }
            if (weaponController.PlayerHasPistol == true)
            {
                movementController.PlayerMovementInput = true;
                animationController.PlayPlayerPistolMoving();
            }
        }

        private void OnInputReleased()
        {
            if (weaponController.PlayerHasPistol == false)
            {
                movementController.PlayerMovementInput = false;
                animationController.PlayPlayerUnarmedIdle();
            }
            if (weaponController.PlayerHasPistol == true)
            {
                movementController.PlayerMovementInput = false;
                animationController.PlayPlayerPistolIdle();
            }
        }
    }
}