using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticleSystem;
    [SerializeField] ParticleSystem deathParticlePrefab;
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
    }

    private void ProcessHit() {
        --hitPoints;
        if (hitPoints <= 0) {   
            KillEnemy();
        } else {
            hitParticleSystem.Play();    
        }
    }

    private void KillEnemy() {
        var deathParticle = Instantiate(deathParticlePrefab, gameObject.transform.position, Quaternion.identity);
        deathParticle.Play();
        deathParticlePrefab.Play();

        Destroy(gameObject);
    }
}
