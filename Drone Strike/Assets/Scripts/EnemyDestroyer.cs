using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject enemyHitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int amountToHit = 10;

    ScoreBoard scoreBoard;
    EnemyHealth enemyhealth;

    bool isEnemyDead;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        enemyhealth = GetComponent<EnemyHealth>();
    }
    private void OnParticleCollision(GameObject other)
    {
        DoDamage(amountToHit);
        if (isEnemyDead)
            KillEnemy();
        ProcessHit();
    }

    public void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
    public void ProcessHit()
    {
        scoreBoard.IncreaseScore(amountToHit);
    }

    public bool DoDamage(int damage)
    {
        isEnemyDead = enemyhealth.DecreaseHealth(damage);
        GameObject hitVFX = Instantiate(enemyHitVFX, transform.position, Quaternion.identity);
        hitVFX.transform.parent = parent;
        return isEnemyDead;
    }
}
