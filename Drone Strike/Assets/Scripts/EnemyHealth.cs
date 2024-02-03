using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] GameObject easyEnemy;
    [SerializeField] GameObject hardEnemy;

    [SerializeField] int easyEnemyHealth = 50;
    [SerializeField] int hardEnemyHealth = 100;

    public bool DecreaseHealth(int damage)
    {
        easyEnemyHealth -= damage;
        hardEnemyHealth -= damage;
        if (hardEnemyHealth <= 0 || easyEnemyHealth <= 0)
        {
            return true;
        }
        return false;
    }
}
