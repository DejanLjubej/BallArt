using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public List<GameObject> BallList = new List<GameObject>();
    public GameObject ballCounter;
    public GameObject startingPoint;
    
    GameObject ball;
    PlayerStats playerStats;
    BallCounter bc;

    public static Vector2 moveDirection;
    public static float spin;
    public static float power;

    void Start()
    {
        bc = ballCounter.GetComponent<BallCounter>();
        playerStats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
    }
    
    public void SpawnTheBall(Vector2 directionOfPointer, float torque, float force)
    {
        ball = BallList[ChooseThisColor.chosenColorNumber];
        if (ball != null)
        {
            if (playerStats.currentNumberOfBalls > 0)
            {
                Vector2 ballDirection = directionOfPointer - new Vector2(this.transform.position.x, this.transform.position.y);
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, ballDirection);
                Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

                moveDirection = ballDirection;
                spin = torque;
                power = force;

                ball.transform.rotation = rotation;
                ball.transform.position = this.transform.position;

                Instantiate(ball);

                playerStats.UseBalls(1);
                ball.gameObject.GetComponent<BallMotor>().AddForceAndTorque(ballDirection, torque, force);
                rb.AddForce(ballDirection * force*1000);
                ball.GetComponent<Rigidbody2D>().AddTorque(torque, ForceMode2D.Impulse);
            }
        }
        bc.UpdateBallCount();
    }
}
