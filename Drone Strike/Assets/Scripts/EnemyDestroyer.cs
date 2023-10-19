using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
        Debug.Log($"{gameObject.name} is destroyed by {other.gameObject.name}");
    }
}
