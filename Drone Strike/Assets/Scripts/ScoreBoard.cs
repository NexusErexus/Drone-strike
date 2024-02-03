using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        Debug.Log(($"Total score: {score}"));
    }

    
}
