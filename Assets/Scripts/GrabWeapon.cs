using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabWeapon : MonoBehaviour
{
    //public bool PlayerGrabbedPistol =false;
    public GameObject Player;
    private Animator _animator;

    private void Start()
    {
        _animator = Player.GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pistol"))
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
        _animator.SetBool("PlayerHasPistol",true);
    }
    
}

