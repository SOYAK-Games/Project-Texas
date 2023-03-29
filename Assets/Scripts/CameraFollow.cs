using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Player;
    private void Update() 
    {
        FollowPlayer();
    }
    private void FollowPlayer()
    {
        var position = Player.position;
        Vector3 newPos = new Vector3 (position.x,position.y,transform.position.z);
        transform.position = newPos;
    }
} 