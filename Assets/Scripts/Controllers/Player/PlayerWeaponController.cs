using System.Collections;
using System.Collections.Generic;
using Data.ValueObjects;
using Managers;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [SerializeField] private PlayerAnimationController AnimationController;
    public bool PlayerHasPistol;
    [SerializeField] private GameObject _bulletTrail;
    [SerializeField] private GameObject pistol;
     private GameObject pistolonground;
    [SerializeField] private float _weaponRange = 15f;
    [SerializeField] private float weaponThrowRange = 8f;
    [SerializeField] private Transform _gunPoint;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Pistol"))
        {
            if (Input.GetMouseButton(1))
            {
                GrabPistol();
                pistolonground = other.gameObject;
                pistolonground.SetActive(false);
            }
        }
    }
    private void GrabPistol()
    {
        PlayerHasPistol = true;
        AnimationController.Animator.SetBool("PlayerHasPistol", true);
    }

    internal void ThrowPistol()
    {
        PlayerHasPistol = false;
        AnimationController.Animator.SetBool("PlayerHasPistol", false);
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
                hittable?.Hit();
            }
            else
            {
                var endPosition = _gunPoint.position + transform.right * _weaponRange;
                trailscript.SetTargetPosition(endPosition);
            }
    }

    public void WeaponThrow()
    {
        var hit = Physics2D.Raycast(_gunPoint.position, transform.right, weaponThrowRange);
        var trail = Instantiate(pistol, _gunPoint.position, transform.rotation);
        var trailscript = trail.GetComponent<BulletTrail>();
        if (hit.collider != null)
        {
            trailscript.SetTargetPosition(hit.point);
            var hittable = hit.collider.GetComponent<IHittable>();
            hittable?.Hit();
        }
        else
        {
            var endPosition = _gunPoint.position + transform.right * weaponThrowRange;
            trailscript.SetTargetPosition(endPosition);

            pistolonground.transform.position = endPosition;
            pistolonground.SetActive(true);
        }


    }
    internal interface IHittable
    {
        void Hit();
    }
}
    
