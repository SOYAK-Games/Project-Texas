<<<<<<< HEAD
using Controllers.Player;
=======
using Controllers;
using Controllers.Player;
using Data;
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
using Data.UnityObjects;
using Data.ValueObjects;
using Signals;
using Sirenix.OdinInspector;
<<<<<<< HEAD
using UnityEngine;
=======
using Unity.VisualScripting;
using UnityEngine;
using Update = Unity.VisualScripting.Update;
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
<<<<<<< HEAD
        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerWeaponController weaponController;
        [SerializeField] private PlayerAnimationController animationController;
        [SerializeField] private MeleeAttackController meleeController;
        [ShowInInspector] private PlayerData _data;
        
=======
        #region Self Variables

        #region Public Variables
        

        #endregion

        #region Serialized Variables

        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerWeaponController weaponController;
        [SerializeField] private PlayerAnimationController animationController;

        #endregion

        #region Private Variables

        [ShowInInspector] private PlayerData _data;

        #endregion

        #endregion

>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
        private void Awake()
        {
            _data = GetPlayerData();
            SendDataToControllers();
        }
<<<<<<< HEAD
=======

>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
        private PlayerData GetPlayerData()
        {
            return Resources.Load<CD_Player>("Data/CD_Player").Data;
        }
<<<<<<< HEAD
=======

>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
        private void SendDataToControllers()
        {
            movementController.GetMovementData(_data.MovementData);
        }
<<<<<<< HEAD
=======

>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
        private void OnEnable()
        {
            SubscribeEvents();
        }
<<<<<<< HEAD
        private void SubscribeEvents()
        {
            PlayerSignals.Instance.onUnarmedMove += OnUnarmedMove;
            PlayerSignals.Instance.onUnarmedIdle += OnUnarmedIdle;
            PlayerSignals.Instance.onPistolShoot += OnPistolShoot;
            PlayerSignals.Instance.onPistolIdle += OnPistolIdle;
            PlayerSignals.Instance.onPistolMove += OnPistolMove;
            PlayerSignals.Instance.onUnarmedAttack += OnUnarmedAttack;
=======

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onUnarmedMove += OnUnarmedMove;
            CoreGameSignals.Instance.onUnarmedIdle += OnUnarmedIdle;
            CoreGameSignals.Instance.onPistolShoot += OnPistolShoot;
            CoreGameSignals.Instance.onPistolIdle += OnPistolIdle;
            CoreGameSignals.Instance.onPistolMove += OnPistolMove;
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
            InputSignals.Instance.onLeftMouseInput += OnLeftMouseInputTaken;
            InputSignals.Instance.onRightMouseInput += OnRightMouseInputTaken;
            InputSignals.Instance.onInputTaken += OnInputTaken;
            InputSignals.Instance.onInputReleased += OnInputReleased;
        }
<<<<<<< HEAD
        private void UnSubscribeEvents()
        {
            PlayerSignals.Instance.onUnarmedMove -= OnUnarmedMove;
            PlayerSignals.Instance.onUnarmedIdle -= OnUnarmedIdle;
            PlayerSignals.Instance.onPistolShoot -= OnPistolShoot;
            PlayerSignals.Instance.onPistolIdle -= OnPistolIdle;
            PlayerSignals.Instance.onPistolMove -= OnPistolMove;
            PlayerSignals.Instance.onUnarmedAttack -= OnUnarmedAttack;
=======

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onUnarmedMove -= OnUnarmedMove;
            CoreGameSignals.Instance.onUnarmedIdle -= OnUnarmedIdle;
            CoreGameSignals.Instance.onPistolShoot -= OnPistolShoot;
            CoreGameSignals.Instance.onPistolIdle -= OnPistolIdle;
            CoreGameSignals.Instance.onPistolMove -= OnPistolMove;
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
            InputSignals.Instance.onLeftMouseInput -= OnLeftMouseInputTaken;
            InputSignals.Instance.onRightMouseInput -= OnRightMouseInputTaken;
            InputSignals.Instance.onInputTaken -= OnInputTaken;
            InputSignals.Instance.onInputReleased -= OnInputReleased;
        }
<<<<<<< HEAD
=======

>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
        private void OnDisable()
        {
            UnSubscribeEvents();
        }
<<<<<<< HEAD
=======

>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
        private void OnUnarmedMove()
        {
            animationController.PlayPlayerUnarmedMoving();
        }
<<<<<<< HEAD
=======

>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
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
<<<<<<< HEAD
=======

>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
        private void OnPistolMove()
        {
            animationController.PlayPlayerPistolMoving();
        }
<<<<<<< HEAD
        private void OnUnarmedAttack()
        {
            animationController.PlayPlayerUnarmedAttack();
        }
        private void OnLeftMouseInputTaken()
        {
            if (weaponController.PlayerHasPistol == true) // Uzak Dövüş
=======
        private void OnLeftMouseInputTaken()
        {
            if (weaponController.PlayerHasPistol)
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
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
<<<<<<< HEAD

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
=======
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
        }

        private void OnRightMouseInputTaken()
        {
            if (weaponController.PlayerHasPistol==true) // pistol yoksa pistolü al
            {
                weaponController.ThrowPistol();
            }
<<<<<<< HEAD

            if (weaponController.isPistolInputTaken == true)
            {
                weaponController.GrabPistol();
            }
=======
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
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