using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEditor.Search;

public class ScoreBoard : MonoBehaviour
{
    TMP_Text scoreText;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        ShowScore(score);
    }
    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
        ShowScore(score);
    }

    public string ShowScore(int score)
    {
        scoreText.text = "Total score: " + score.ToString();
        scoreText.fontStyle = FontStyles.UpperCase;
        return scoreText.text;
    }

    
}
