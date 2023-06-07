using System;
using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
public class Enemy : MonoBehaviour, IHittable
{
    public int hitPoints = 2;
    public EnemyController _enemyController;

    public void ReceiveHit()
    {
        hitPoints -= 1;
        if (hitPoints <= 0)
        {
            _enemyController.ChangeSprite();
            _enemyController.navAgent.speed = 0;
            _enemyController.isPatrolling = false;
            Destroy(GetComponent<Animator>());
            Destroy(GetComponent<EnemyController>());
            Destroy(GetComponent<Collider2D>());
        }
    }
}