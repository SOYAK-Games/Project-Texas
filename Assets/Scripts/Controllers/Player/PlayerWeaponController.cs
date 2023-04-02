using System.Collections;
using System.Collections.Generic;
using Data.ValueObjects;
using Managers;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public bool PlayerHasPistol = false;
    [SerializeField] private PlayerAnimationController animationController;
    [SerializeField] private GameObject _bulletTrail;
    [SerializeField] private GameObject pistol;
    [SerializeField] private float _weaponRange = 15f;
    [SerializeField] private float weaponThrowRange = 8f;
    [SerializeField] private Transform _gunPoint;
    private GameObject PistolOnGround;
    internal bool a = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Pistol"))
        {
            if (Input.GetMouseButton(1))
            {
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
                    hittable.ReceiveHit();
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
        }
        else
        {
            var endPosition = _gunPoint.position + transform.right * weaponThrowRange;
            trailscript.SetTargetPosition(endPosition);

            PistolOnGround.transform.position = endPosition;
            PistolOnGround.SetActive(true);
        }

    }

    private interface IHittable
    {
        void ReceiveHit();
    }
}
    
