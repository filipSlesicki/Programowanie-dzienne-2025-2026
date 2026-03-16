using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;
    [SerializeField] TMP_Text scoreText;

    private void Start()
    {
        EnemyMovement.OnEnemyDeath += OnEnemyDeath;
    }

    private void OnEnemyDeath()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
