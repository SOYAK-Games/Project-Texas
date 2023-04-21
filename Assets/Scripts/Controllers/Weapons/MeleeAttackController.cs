using Interfaces;
using UnityEngine;

public class MeleeAttackController : MonoBehaviour
{

    // Interface ile düzenlenecek 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<Enemy>().ReceiveHit();
        }
    }
}