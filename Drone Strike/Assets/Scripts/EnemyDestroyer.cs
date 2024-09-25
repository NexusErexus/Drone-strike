using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject enemyHitVFX;
    

    [SerializeField] int amountToHit = 10;

    ScoreBoard scoreBoard;
    EnemyHealth enemyhealth;
    GameObject parentGameObject;

    bool isEnemyDead;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        enemyhealth = GetComponent<EnemyHealth>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");

    }
    private void OnParticleCollision(GameObject other)
    {
        DoDamage(amountToHit);
        if (isEnemyDead)
            KillEnemy();
        //ProcessHit();
    }

    public void KillEnemy()
    {
        scoreBoard.IncreaseScore(amountToHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        //vfx.transform.parent = parentGameObject.transform;
        fx.transform.SetParent(parentGameObject.transform);
        Destroy(gameObject);
    }
    /*public void ProcessHit()
    {
        scoreBoard.IncreaseScore(amountToHit);
    }*/

    public bool DoDamage(int damage)
    {
        isEnemyDead = enemyhealth.DecreaseHealth(damage);
        GameObject hitVFX = Instantiate(enemyHitVFX, transform.position, Quaternion.identity);
        //hitVFX.transform.parent = parentGameObject.transform;
        hitVFX.transform.SetParent(parentGameObject.transform);
        return isEnemyDead;
    }
}
