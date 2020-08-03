using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;
public class LevelWon : MonoBehaviour
{
    public Text textOfScore;
    public static bool levelWon = false;
    
    //When the panel showing the game won screen is enabled
    void OnEnable()
    {
        //HandleLevelWon();
    }

    public void HandleLevelWon()
    {
        string thisSceneName = SceneManager.GetActiveScene().name;
        HighScore hs = GameObject.FindObjectOfType<HighScore>();
        
        textOfScore.text = "Your Score: "+LevelScore.score.ToString();
                
        hs.SetHighscore(SceneManager.GetActiveScene().buildIndex-2, LevelScore.score);
        string levelNumberString = thisSceneName.Replace("Level", "").Trim();
        int levelNumber = int.Parse(levelNumberString) + 1;
        string levelLock = "Level" + levelNumber + "Lock";
        PlayerPrefs.SetInt(levelLock, 1);
    }    
}
