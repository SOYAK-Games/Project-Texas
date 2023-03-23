using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    #region Animation

    public bool isCharacterMoving = false;
    public Animator _animator;

    #endregion
    
    #region Shooting Variables
    [SerializeField] private GameObject _bulletTrail;
    [SerializeField] private float _weaponRange = 10f;
    [SerializeField] private Transform _gunPoint;
    private bool PlayerHasPistol = false;
    
    #endregion
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        LookAtMouse();
        Move();
        PistolCheck();
        Shoot();
        CheckIfMoving();
        CheckInput();
    }

    private void LookAtMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = mousePos - new Vector2(transform.position.x, transform.position.y);
    }



    #region Movemental
    
    private void Move()
    {
        var input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _rigidbody.velocity = input.normalized * _speed;
    }
    private void CheckIfMoving() //Animasyon Oynasın mı?
    {
        if (isCharacterMoving == true)
        {
            Move();
            _animator.SetBool("PlayerMoving", true);
        }
        if (isCharacterMoving == false)
        {
            _animator.SetBool("PlayerMoving", false);
        }
    }
    private void CheckInput() // Yürümek için tuşa basılıyor mu?
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            isCharacterMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            isCharacterMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            isCharacterMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            isCharacterMoving = true;
        }

        if (Input.GetKey(KeyCode.D) != true && Input.GetKey(KeyCode.W) != true && Input.GetKey(KeyCode.S) != true &&
            Input.GetKey(KeyCode.A) != true)
        {
            StopPlayer();
        }
    }
    public void StopPlayer()
    {
        isCharacterMoving = false;
        _rigidbody.velocity = Vector3.zero;
    }

    #endregion
    

    #region Shooting
    

    private void Shoot()
    {
        if (PlayerHasPistol)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_animator.GetCurrentAnimatorStateInfo(0).IsName("PlayerPistolShoot")&&Input.GetMouseButtonDown(0))
                {
                    return;
                }
                else
                {
                    PistolAnimation();
                    var hit = Physics2D.Raycast(
                        _gunPoint.position, transform.right, _weaponRange);

                    var trail = Instantiate(
                        _bulletTrail, _gunPoint.position, transform.rotation);
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
            }
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
        _animator.Play("PlayerPistolShoot");
        //_animator.SetBool("PlayerShootPistol", true);
        //StartCoroutine(ResetAnimation());
    }
    private IEnumerator ResetAnimation() 
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            _animator.SetBool("PlayerShootPistol", false);
        }
    }
    #endregion
}

internal interface IHittable
{
    void Hit();
}
