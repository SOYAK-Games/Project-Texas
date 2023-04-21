using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
public class Enemy : MonoBehaviour, IHittable
{
    [SerializeField] public int hitPoints = 1;
    
    public void ReceiveHit()
    {
        
        hitPoints -= 1;
        if (hitPoints <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}