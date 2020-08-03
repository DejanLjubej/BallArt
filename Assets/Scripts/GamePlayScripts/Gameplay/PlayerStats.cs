using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    int numberOfBalls=3;

    public int currentNumberOfBalls { get; private set; }
    public int currentNumberOfBallsLeft { get; private set; }

    string _currentLevelName;
    int _thisSceneHighScore;
    int _moneyAfterHS;
    int _moneyFinal;
    int _moneyBefore;
    //UI
    public GameObject gameOverUI;
    public GameObject gameWonUI;
    public GameObject gamePausedUI;

    public int extraBalls;

    OnLossUnityInterstitial lossInterstitial;

    [SerializeField] LevelWon lw;

    void Awake()
    {
        gameOverUI.SetActive(true);
        gameWonUI.SetActive(true);
        gamePausedUI.SetActive(true);
        _currentLevelName = SceneManager.GetActiveScene().name;
        _thisSceneHighScore = PlayerPrefs.GetInt(_currentLevelName + "HS", 0);

        lossInterstitial = GetComponent<OnLossUnityInterstitial>();

        gameOverUI.SetActive(false);
        gameWonUI.SetActive(false);
        gamePausedUI.SetActive(false);
        currentNumberOfBalls = numberOfBalls;
        Time.timeScale = 1;
        Points.hitsInARow = 0;
        if(lw == null)
        {
            lw = FindObjectOfType<LevelWon>();
        }
        currentNumberOfBallsLeft = currentNumberOfBalls;
    }

    public void UseBalls(int ballsUsed)
    {
        currentNumberOfBalls -= ballsUsed;
    }
    public void BallStopped()
    {
        currentNumberOfBallsLeft -= 1;
    }

    public void GameOver() 
    {
        Time.timeScale = 0;
        if (!gameOverUI.activeSelf) { 
            gameOverUI.SetActive(true);
        }
        lossInterstitial.ShowInterstitialOnLoss();
    }


    public void GameWon()
    {
        Time.timeScale = 0;
        lw.HandleLevelWon();

        if (!gameWonUI.activeSelf)
        {
            gameWonUI.SetActive(true);
        }

        _moneyBefore = PlayerPrefs.GetInt("PlayerCurrentMoney", 0);

        if(_thisSceneHighScore <= LevelScore.score)
        {
            _moneyAfterHS = LevelScore.score-_thisSceneHighScore;
            _moneyFinal = _moneyBefore + _moneyAfterHS;
        }
        else
        {
            _moneyFinal = _moneyBefore+LevelScore.score;
        }

        PlayerPrefs.SetInt("PlayerCurrentMoney", _moneyFinal);
    }
    public void addBalls()
    {
        currentNumberOfBalls += extraBalls;
        currentNumberOfBallsLeft += 1;
        Debug.LogError("To see how many times I addBalls()");
    }
}
