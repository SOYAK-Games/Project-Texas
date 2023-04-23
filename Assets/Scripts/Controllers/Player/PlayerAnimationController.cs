
using System;
using Data.ValueObjects;
using Managers;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator Animator;
    internal void PlayPlayerShooting()
    {
        Animator.Play("PlayerPistolShoot");
<<<<<<< HEAD
        Animator.SetBool("PlayerMoving", false);
=======
            Animator.SetBool("PlayerMoving", false);
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
    }

    internal void PlayPlayerUnarmedIdle()
    {
        Animator.SetBool("PlayerMoving", false);
        Animator.SetBool("PlayerHasPistol", false);
<<<<<<< HEAD
        Animator.SetBool("UnarmedAttack", false);
=======
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
    }
    internal void PlayPlayerPistolIdle()
    {
        Animator.SetBool("PlayerMoving", false);
        Animator.SetBool("PlayerShootPistol", false);
    }
    internal void PlayPlayerUnarmedMoving()
    {
        Animator.SetBool("PlayerMoving", true);
<<<<<<< HEAD
        Animator.SetBool("UnarmedAttack", false);
=======
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
    }
    internal void PlayPlayerPistolMoving()
    {
        Animator.SetBool("PlayerMoving", true);
    }
<<<<<<< HEAD
    internal void PlayPlayerUnarmedAttack()
    {
        Animator.SetBool("UnarmedAttack", true);
        Animator.Play("PlayerUnarmedAttack");
    }

    internal void PlayerPlayerUnarmedAttackMoving()
    {
        Animator.SetBool("PlayerMoving", true);
        Animator.SetBool("UnarmedAttack", true);
    }
=======
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
    
}
