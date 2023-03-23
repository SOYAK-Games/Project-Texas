using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Composites;

public class Bullet : MonoBehaviour
{
    private float speed = 1f;
    private Vector3 mousePosition;
    private Camera _camera;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private Collider2D _collider;
    private Vector2 BulletPath;

    private void Start()
    {

        AmmoRotation();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = mousePosition * speed;
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
        mousePosition = _camera.ScreenToWorldPoint (Input.mousePosition);
        _rigidbody2D.transform.eulerAngles = new Vector3 (0,0,Mathf.Atan2((mousePosition.y-transform.position.y),(mousePosition.x-transform.position.x))*Mathf.Rad2Deg);
        BulletPath = mousePosition;
    }
    
    
}
