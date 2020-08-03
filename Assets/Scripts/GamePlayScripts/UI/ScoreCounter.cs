using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static Text text;
    int numberToDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        int numberToDisplay = LevelScore.score;
        UpdateBounceCount();
    }

    public static void UpdateBounceCount()
    {
        LevelScore pointsNeeded = LevelScore.FindObjectOfType<LevelScore>();   
        text.text = "SCORE: " + LevelScore.score + "/" + pointsNeeded.pointsNeededToFinishLevel +"      MAX: "+ pointsNeeded.pointsNeededToFinishLevel*2;
    }
}
