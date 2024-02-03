using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int amountToHit = 10;

    ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    private void OnParticleCollision(GameObject other)
    {
        GameObject vfx =  Instantiate(deathVFX,transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);

        scoreBoard.IncreaseScore(amountToHit);
        //Debug.Log($"{gameObject.name} is destroyed by {other.gameObject.name}");
    }
}
