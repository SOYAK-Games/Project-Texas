using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Composites;

public class Bullet : MonoBehaviour
{
    private float Speed = 1f;
    private Vector3 _mousePosition;
    private Camera _camera;
    [SerializeField] private Rigidbody2D _rigidbody;
    private Collider2D _collider;

    private void Start()
    {
        AmmoRotation();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _mousePosition * Speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false); 
        }
    }

    private void AmmoRotation()
    {
        _camera = Camera.main;
        _mousePosition = _camera.ScreenToWorldPoint (Input.mousePosition);
        _rigidbody.transform.eulerAngles = new Vector3 (0,0,Mathf.Atan2((_mousePosition.y-transform.position.y),(_mousePosition.x-transform.position.x))*Mathf.Rad2Deg);
    }
    
    
}
