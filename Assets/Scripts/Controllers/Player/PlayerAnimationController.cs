using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator animator;
    public string currentState;
    internal bool PlayerHasPistol = false;
    internal bool PlayerMoving = false;
    internal bool PlayerAttacking;
    
    private const string PlayerPistolShoot = "PlayerPistolShoot";
    private const string PlayerPistolIdle = "PlayerPistolIdle";
    private const string PlayerPistolMoving = "PlayerPistolWalk";
    private const string PlayerUnarmedAttack = "PlayerUnarmedAttack";
    private const string PlayerUnarmedIdle = "PlayerUnarmedIdle";
    private const string PlayerUnarmedMoving = "PlayerUnarmedWalk";

    internal void PlayAnimation()
    {
        if (!PlayerHasPistol)
        {
            if (!PlayerMoving & !PlayerAttacking)
            {
                ChangeAnimationState(PlayerUnarmedIdle);
            }
            if (PlayerMoving)
            {
                ChangeAnimationState(PlayerUnarmedMoving);
            }
            if (PlayerAttacking)
            {
                ChangeAnimationState(PlayerUnarmedAttack);
                PlayerAttacking = !PlayerAttacking;
            } 
        }
        if (PlayerHasPistol)
        {
            if (!PlayerMoving & !PlayerAttacking)
            {
                ChangeAnimationState(PlayerPistolIdle);
            }
            if (PlayerMoving)
            {
                ChangeAnimationState(PlayerPistolMoving);
            }
            if (PlayerAttacking)
            {
                ChangeAnimationState(PlayerPistolShoot);
                PlayerAttacking = !PlayerAttacking;
            }
        }
    }

    private void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
        {
            return;
        }
        animator.Play(newState);
        currentState = newState;
    }
}


