using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private void Update() 
    {
        FollowPlayer();
    }
    private void FollowPlayer()
    {
        Vector3 newPos = new Vector3 (player.transform.position.x, player.transform.position.y, transform.position.z); // take players x and y position and keep camera z position, then assigned it to the transform position
        transform.position = newPos;
    }
}
