using Interfaces;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
public class Enemy : MonoBehaviour, IHittable
{
    [SerializeField] private GameObject _blood;
    [SerializeField] private Transform Player;
    [SerializeField] private int hitPoints;
    private IHittable _hittableImplementation;

    public void ReceiveHit(RaycastHit2D hit)
        {
            Debug.Log("hit acquired");
            Instantiate(_blood, hit.point, Quaternion.Euler(hit.normal));
            transform.right = Player.position - transform.position;
            hitPoints -= 1;
            if (hitPoints == 0)
            {
                gameObject.SetActive(false); 
            }
        }
        private void GetDamaged(RaycastHit2D hitInfo)
        {


        }

        
}
