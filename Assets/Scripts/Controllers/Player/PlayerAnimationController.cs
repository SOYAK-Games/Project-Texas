
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
            Animator.SetBool("PlayerMoving", false);
    }

    internal void PlayPlayerUnarmedIdle()
    {
        Animator.SetBool("PlayerMoving", false);
        Animator.SetBool("PlayerHasPistol", false);
    }
    internal void PlayPlayerPistolIdle()
    {
        Animator.SetBool("PlayerMoving", false);
        Animator.SetBool("PlayerShootPistol", false);
    }
    internal void PlayPlayerUnarmedMoving()
    {
        Animator.SetBool("PlayerMoving", true);
    }
    internal void PlayPlayerPistolMoving()
    {
        Animator.SetBool("PlayerMoving", true);
    }
    
}
