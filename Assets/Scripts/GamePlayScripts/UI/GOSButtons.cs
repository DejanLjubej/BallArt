using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections.Generic;
public class GOSButtons : MonoBehaviour
{
    public BallCounter bc;

    PlayerStats playerStats;
    public void RetryButton()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevelButton()
    {
        string thisSceneName = SceneManager.GetActiveScene().name;
        int levelNumber = int.Parse(thisSceneName.Replace("Level", ""))+1;
        string levelLock = "Level" + levelNumber + "Lock";

        PlayerPrefs.SetInt(levelLock, 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GetMoreBalls()
    {
        playerStats.gameOverUI.SetActive(false);
        playerStats.gamePausedUI.SetActive(false);
        Time.timeScale = 1;
        playerStats.addBalls();
        bc.UpdateBallCount();
    }
    public void Resume()
    {
        playerStats.gamePausedUI.SetActive(false);
        Debug.LogError("Why Is PasuePannel Still Active" + playerStats.gamePausedUI.activeSelf);
        Time.timeScale = 1;
    }

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
    }
}
