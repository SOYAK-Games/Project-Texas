<<<<<<< HEAD
using System;
using Interfaces;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour, IHittable
=======
using System.Collections;
using System.Collections.Generic;
using Data.ValueObjects;
using Managers;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
{
    public bool PlayerHasPistol = false;
    [SerializeField] private PlayerAnimationController animationController;
    [SerializeField] private GameObject _bulletTrail;
    [SerializeField] private GameObject pistol;
    [SerializeField] private float _weaponRange = 15f;
    [SerializeField] private float weaponThrowRange = 8f;
    [SerializeField] private Transform _gunPoint;
<<<<<<< HEAD
    private Enemy EnemyScript;
    private int hitPoints;
    private GameObject CollectiblePistol;
    public bool isPistolInputTaken = false;


=======
    private GameObject PistolOnGround;
    internal bool a = false;
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Pistol"))
        {
            if (Input.GetMouseButton(1))
            {
<<<<<<< HEAD
                isPistolInputTaken = true;
                GrabPistol();
                CollectiblePistol = other.gameObject;
                CollectiblePistol.SetActive(false);
            }
        }
    }

    internal void GrabPistol()
    {
        PlayerHasPistol = true;
        animationController.Animator.SetBool("PlayerHasPistol", true);
        isPistolInputTaken = false;
=======
                GrabPistol();
                PistolOnGround = other.gameObject;
                PistolOnGround.SetActive(false);
            }

        }
    }
    private void GrabPistol()
    {
        PlayerHasPistol = true;
        animationController.Animator.SetBool("PlayerHasPistol", true);
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
    }

    internal void ThrowPistol()
    {
        PlayerHasPistol = false;
        animationController.Animator.SetBool("PlayerHasPistol", false);
        WeaponThrow();
    }

    public void Shoot()
    {
        var hit = Physics2D.Raycast(_gunPoint.position, transform.right, _weaponRange);
        var trail = Instantiate(_bulletTrail, _gunPoint.position, transform.rotation);
            var trailscript = trail.GetComponent<BulletTrail>();
            if (hit.collider != null)
            {
                trailscript.SetTargetPosition(hit.point);
                var hittable = hit.collider.GetComponent<IHittable>();
                if (hittable != null)
                {
<<<<<<< HEAD
                    hittable?.ReceiveHit();
=======
                    hittable.ReceiveHit();
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
                }
            }
            else
            {
                var endPosition = _gunPoint.position + transform.right * _weaponRange;
                trailscript.SetTargetPosition(endPosition);
            }
    }

    private void WeaponThrow()
    {
        var hit = Physics2D.Raycast(_gunPoint.position, transform.right, weaponThrowRange);
        var trail = Instantiate(pistol, _gunPoint.position, transform.rotation);
        var trailscript = trail.GetComponent<BulletTrail>();
        if (hit.collider != null)
        {
            trailscript.SetTargetPosition(hit.point);
            var hittable = hit.collider.GetComponent<IHittable>();
            hittable?.ReceiveHit();
<<<<<<< HEAD
            
            CollectiblePistol.transform.position = hit.point;
            CollectiblePistol.SetActive(true);
=======
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
        }
        else
        {
            var endPosition = _gunPoint.position + transform.right * weaponThrowRange;
            trailscript.SetTargetPosition(endPosition);

<<<<<<< HEAD
            CollectiblePistol.transform.position = endPosition;
            CollectiblePistol.SetActive(true);
        }
    }

    public void ReceiveHit()
    {
        hitPoints = EnemyScript.hitPoints;
        
        hitPoints -= 2;
        if (hitPoints <= 0)
        {
            gameObject.SetActive(false);
        }
=======
            PistolOnGround.transform.position = endPosition;
            PistolOnGround.SetActive(true);
        }

    }

    private interface IHittable
    {
        void ReceiveHit();
>>>>>>> 8318aad4e4e6aa9b36523401c81b273cd45597ef
    }
}
    
