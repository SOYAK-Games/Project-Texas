
using System;
using Data.ValueObjects;
using Managers;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;
    public string currentState;
    internal bool PlayerHasPistol = false;
    internal bool PlayerMoving = false;
    internal bool PlayerAttacking = false;

    private const string PlayerPistolShoot = "PlayerPistolShoot";
    private const string PlayerPistolIdle = "PlayerPistolIdle";
    private const string PlayerPistolMoving = "PlayerPistolWalk";
    private const string PlayerUnarmedAttack = "PlayerUnarmedAttack";
    private const string PlayerUnarmedIdle = "PlayerUnarmedIdle";
    private const string PlayerUnarmedMoving = "PlayerUnarmedWalk";

    internal void PlayAnimation()
    {
        if (PlayerMoving == false & PlayerHasPistol == false & PlayerAttacking == false)
        {
            ChangeAnimationState(PlayerUnarmedIdle);
            PlayerAttacking = false;

        }
        if (PlayerMoving == true & PlayerHasPistol == false )
        {
            ChangeAnimationState(PlayerUnarmedMoving);
        }
        if (PlayerHasPistol == false & PlayerAttacking == true)
        {
            ChangeAnimationState(PlayerUnarmedAttack);
            PlayerAttacking = false;
        } 
        
        
        if (PlayerMoving == false & PlayerHasPistol == true & PlayerAttacking == false)
        {
            ChangeAnimationState(PlayerPistolIdle);
            PlayerAttacking = false;
        }
        if (PlayerMoving == true & PlayerHasPistol == true )
        {
            ChangeAnimationState(PlayerPistolMoving);
            
        }
        if ( PlayerHasPistol == true & PlayerAttacking == true )
        { 
            ChangeAnimationState(PlayerPistolShoot); 
            PlayerAttacking = false;
        }
    }

    private void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
        {
            currentState = null;
        }
        animator.Play(newState);
        currentState = newState;
    }

}


