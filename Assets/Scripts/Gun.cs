using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using Object = System.Object;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawnPoint;
    private bool PlayerHasPistol = false;
    public Animator _animator;
    public bool canFire;
    private float timer;
    public float FireCooldown = 1;

    private void Update()
    {
        PistolCheck();
        if (PlayerHasPistol == true)
        {
            if (canFire==true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    canFire = false;
                    Fire();
                    PistolAnimation();
                } 
            }
            if (canFire == false)
            {
                timer += Time.deltaTime;
                if (timer > FireCooldown)
                {
                    canFire = true;
                    timer = 0;
                }
            }
        }
    }

    private void Fire()
    {
        GameObject bullet = ObjectPooling.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawnPoint.position;
            bullet.SetActive(true);
        }
    }
    private void PistolCheck()
    {
        if(_animator.GetBool("PlayerHasPistol"))
        {
            PlayerHasPistol = true;
        }
        else if (!_animator.GetBool("PlayerHasPistol"))
        {
            PlayerHasPistol = false;
        }
    }
    
    private void PistolAnimation()
    {
        _animator.SetBool("PlayerShootPistol", true);
        StartCoroutine(ResetAnimation());
    }
    private IEnumerator ResetAnimation() 
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            _animator.SetBool("PlayerShootPistol", false);
        }
    }

    private IEnumerator SmallTimer()
    {
        yield return new WaitForSeconds(1f);

    }


}
