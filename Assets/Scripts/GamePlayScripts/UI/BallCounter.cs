using UnityEngine;
using UnityEngine.UI;

public class BallCounter : MonoBehaviour
{
    Text text;
    static PlayerStats playerStats;
    void Start()
    {
        text = this.GetComponent<Text>();
        playerStats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        int numberToDisplay = playerStats.currentNumberOfBalls;
        UpdateBallCount();
    }

    public void UpdateBallCount()
    {
        text.text = "BALLS REMAINING: " + playerStats.currentNumberOfBalls;
    }
}
