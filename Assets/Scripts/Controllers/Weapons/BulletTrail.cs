using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private float _progress;

    [SerializeField] private float Speed;
    private void Start()
    {
        _startPosition = transform.position.WithAxis(Axis.Z, -1);
    }
    
    private void Update()
    {
        _progress += Time.deltaTime * Speed;
        transform.position = Vector3.Lerp(_startPosition, _targetPosition, _progress);
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        _targetPosition = targetPosition.WithAxis(Axis.Z, -1);
    }
}
