using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Movement

    [SerializeField] private float _movementSpeed;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;
    private Vector2 _smoothMovementInput;
    private Vector2 _movementVectorSmoothVelocity;

    #endregion

    #region Movement Animation

    public bool isCharacterMoving = false;
    public Animator _animator;

    #endregion

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInput();   
        CheckIfMoving();
    }

    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void CheckIfMoving() //Animasyon Oynasın mı?
    {
        if (isCharacterMoving == true)
        {
            SetPlayerVelocity();
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

    private void SetPlayerVelocity() //Hızı Ayarla
    {
        _smoothMovementInput = Vector2.SmoothDamp(_smoothMovementInput,_movementInput,
            ref _movementVectorSmoothVelocity,0.1f);
        
        _rigidbody.velocity = _smoothMovementInput * _movementSpeed;
    }

    public void StopPlayer()
    {
        isCharacterMoving = false;
        _rigidbody.velocity = Vector3.zero;
    }
    

}
