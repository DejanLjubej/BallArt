using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWinPoint : MonoBehaviour
{
    [SerializeField]
    private int _adjustmentForBallNumber;

    LevelScore _levelScore;

    int _maxScore;
    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerStats playerStats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        int _scoreBeforeComparingWithMaxScore = LevelScore.score + (_adjustmentForBallNumber * playerStats.currentNumberOfBalls);

        if (_scoreBeforeComparingWithMaxScore < _maxScore)
        {
            LevelScore.score = _scoreBeforeComparingWithMaxScore;
        }
        else
        {
            LevelScore.score = _maxScore;
        }
        playerStats.GameWon();
    }

    void Start()
    {
        _levelScore = FindObjectOfType<LevelScore>();
        _maxScore = _levelScore.pointsNeededToFinishLevel*2;
    }
}
