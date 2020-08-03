using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelect : MonoBehaviour
{
    string levelText;
    public Text scoreText;
    public Image lockImage;
    public Image colorOfVictory;

    void Start()
    {
        levelText = this.gameObject.name.Replace("(Clone)", "").Trim();

        string keyForHighScorePrefs = levelText + "HS";
        scoreText.text = PlayerPrefs.GetInt(keyForHighScorePrefs, 0).ToString();
        if(levelText == "Level1")
        {
            PlayerPrefs.SetInt(levelText+"Lock", 1);

        }
        if(PlayerPrefs.GetInt(levelText+"Lock") == 1)
        {
            lockImage.gameObject.SetActive(false);
            HandleColorOfVictory();
        }
    }
    public void PlayLevel()
    {
        if (PlayerPrefs.GetInt(levelText+"Lock", 0) ==1)
        {
            SceneManager.LoadScene(levelText);
        }
    }
    void HandleColorOfVictory()
    {
        if(PlayerPrefs.GetInt(levelText+"HS", 0) > 0)
        {
            colorOfVictory.gameObject.SetActive(true);
            colorOfVictory.color = new Color32(255,197,1,255);
        }
        else
        {
            colorOfVictory.gameObject.SetActive(true);
            colorOfVictory.color = new Color32(255, 255, 255, 255);
        }
    }
}
