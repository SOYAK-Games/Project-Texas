using UnityEngine;

public class BodyMouseRotation : MonoBehaviour
{
    private Vector3 mousePosition;

    public Camera _camera;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }
	
    private void Update()
    {
        RotateToCamera ();
    }

    private void RotateToCamera() 
    {
        mousePosition = _camera.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z-_camera.transform.position.z));
        _rigidbody.transform.eulerAngles = new Vector3 (0,0,Mathf.Atan2((mousePosition.y-transform.position.y),(mousePosition.x-transform.position.x))*Mathf.Rad2Deg);
    }

    
    
}
