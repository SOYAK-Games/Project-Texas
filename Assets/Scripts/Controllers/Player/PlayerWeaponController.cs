using System;
using Interfaces;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour, IHittable
{
    public bool PlayerHasPistol = false;
    [SerializeField] private PlayerAnimationController animationController;
    [SerializeField] private GameObject _bulletTrail;
    [SerializeField] private GameObject pistol;
    [SerializeField] private float _weaponRange = 15f;
    [SerializeField] private float weaponThrowRange = 8f;
    [SerializeField] private Transform _gunPoint;
    private Enemy EnemyScript;
    private int hitPoints;
    private GameObject CollectiblePistol;

    public bool IsPlayerOnTopOfPistol = false;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Pistol"))
        {
            IsPlayerOnTopOfPistol = true;
            CollectiblePistol = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pistol"))
        {
            IsPlayerOnTopOfPistol = false;
        }
    }

    internal void GrabPistol()
    {
        PlayerHasPistol = true;
        CollectiblePistol.SetActive(false);
    }

    internal void ThrowPistol()
    {
        WeaponThrow();
        PlayerHasPistol = false;
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
                    hittable?.ReceiveHit();
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
        if (PlayerHasPistol == true)
        {
            var hit = Physics2D.Raycast(_gunPoint.position, transform.right, weaponThrowRange);
            var trail = Instantiate(pistol, _gunPoint.position, transform.rotation);
            var trailscript = trail.GetComponent<BulletTrail>();
            if (hit.collider != null)
            {
                trailscript.SetTargetPosition(hit.point);
                var hittable = hit.collider.GetComponent<IHittable>();
                hittable?.ReceiveHit();

                CollectiblePistol.transform.position = hit.point;
                CollectiblePistol.SetActive(true);
            }
            else
            {
                var endPosition = _gunPoint.position + transform.right * weaponThrowRange;
                trailscript.SetTargetPosition(endPosition);

                CollectiblePistol.transform.position = endPosition;
                CollectiblePistol.SetActive(true);
            }
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
    }
}
    
