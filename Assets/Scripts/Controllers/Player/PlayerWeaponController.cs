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
    [SerializeField] private float _weaponRange = 15f;
    [SerializeField] private Transform _gunPoint;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Pistol"))
        {
            if (Input.GetMouseButton(1))
            {
                GrabPistol();   
                other.gameObject.SetActive(false);
            }
        }
    }
    private void GrabPistol()
    {
        PlayerHasPistol = true;
        AnimationController.Animator.SetBool("PlayerHasPistol", true);
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
    internal interface IHittable
    {
        void Hit();
    }
}
    
