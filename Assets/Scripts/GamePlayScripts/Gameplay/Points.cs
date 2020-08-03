using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static int hitsInARow = 0;

    SpriteRenderer objectSpriteRenderer;
    public int pointsGainedByCollisionOnThisObject = 1;
    List<Color> colorsThatHitTheObject;

    float startTime=0;
    Color thisColor;
    Color ballColor;
    Color finalColor;
    Color startColor;
    // Check collisions &if was hit by ball get the color of the ball
    //check if the color has touched the object before
    //if no give points to player and channge the color of object
    //if yes do nothing


    void OnCollisionEnter2D(Collision2D col)
    {
        thisColor =objectSpriteRenderer.color;
        if (col.gameObject.tag == "Ball")
        {
            ballColor = col.gameObject.GetComponent<SpriteRenderer>().color;

            if(!colorsThatHitTheObject.Contains(ballColor))
            {
                finalColor = ballColor;
                startColor = thisColor;

                colorsThatHitTheObject.Add(ballColor);
                LevelScore.score += pointsGainedByCollisionOnThisObject + hitsInARow;
                ScoreCounter.UpdateBounceCount();
                startTime = 0;
                StartCoroutine("ChangeColor");
                hitsInARow += 1;
            }
            else
            {
                hitsInARow = 0;
            }
        }
    }

    IEnumerator ChangeColor()
    {
        while (startTime < 0.5)
        {
            objectSpriteRenderer.color = Color.Lerp(startColor, finalColor, startTime);
            yield return null;
        }
    }

    void Update()
    {
        startTime += Time.deltaTime / 4;
    }

    void Start()
    {
            colorsThatHitTheObject = new List<Color>();
            objectSpriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
            thisColor=objectSpriteRenderer.color;
            ballColor = thisColor;
            colorsThatHitTheObject.Add(thisColor);
    }
}
