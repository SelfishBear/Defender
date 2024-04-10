using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class KillCounterTxt : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _killCounterTxt;
    private int _score = 0;

    private void OnEnable()
    {
        Enemy.OnEnemyDeath += AddScore;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDeath -= AddScore;
    }

    private void AddScore()
    {
        _score++;
        _killCounterTxt.text = "Kills: " + _score;
    }
}
