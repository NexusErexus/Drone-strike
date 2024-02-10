using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //[SerializeField] GameObject healthEnemy;

    [SerializeField] int enemyHealth = 50;

    public bool DecreaseHealth(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0)
        {
            return true;
        }
        return false;
    }
}
