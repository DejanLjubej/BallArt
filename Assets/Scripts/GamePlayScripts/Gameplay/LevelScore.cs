using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScore : MonoBehaviour
{
    public static int score;

    public int pointsNeededToFinishLevel;

    public GameObject endPoint;
    CircleCollider2D endCollider;
    SpriteRenderer endSpriteRenderer;

    void Start()
    {
        endCollider = endPoint.GetComponent<CircleCollider2D>();
        endSpriteRenderer = endPoint.GetComponent<SpriteRenderer>();
        endSpriteRenderer.color = new Color(1,1,1,0.1f);
        endCollider.enabled = false;
    }
    void Update()
    {
        if(score >= pointsNeededToFinishLevel)
        {
            endSpriteRenderer.color = new Color(1, 1, 1, 1f);
            endCollider.enabled = true;
        }
    }
}
