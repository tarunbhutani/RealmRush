using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;

    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other) {
        print("I'm hit");
        ProcessHit();
    }

    private void ProcessHit() {
        print("Hit points are " + hitPoints);
        --hitPoints;
        if (hitPoints <= 1) {   
            KillEnemy();
        }
    }

    private void KillEnemy() {
        Destroy(gameObject);
    }
}
