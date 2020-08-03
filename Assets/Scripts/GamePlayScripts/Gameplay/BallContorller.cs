using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BallContorller : MonoBehaviour
{
    private Vector3 mousePos;
    private Vector2 mousePos2D;
    private RaycastHit2D hit;
    
    private SpawnBall spawn;
    
    float torque;
    float clickTimer;
    public float force;
    public float minimumTorque = 20;

    private bool isTorqueLeft;
    private bool isTorqueRight;

    private GameObject ball;
    public GameObject torqueRightSlider;
    public GameObject torqueLeftSlider;
    
    [SerializeField]
    float holdTime = 1.5f;

  
    public void SpawnTheBall()
    {
        if(torque == 0)
        {
            torque = minimumTorque;
        }
        spawn = FindObjectOfType<SpawnBall>();
        ball = GameObject.FindGameObjectWithTag("Ball");
        spawn.SpawnTheBall(mousePos2D, torque, force);
    }
    //Torque controlls
    #region
    public void TroqueLeftSlider()
    {
        Slider rightSlider = torqueRightSlider.GetComponent<Slider>();
        rightSlider.value = 0;
        Slider leftSlider = torqueLeftSlider.GetComponent<Slider>();
        float value = leftSlider.value;
        clickTimer = 0;
        torque = -1000 * value;

    }
    public void TroqueRightSlider()
    {
        Slider leftSlider = torqueLeftSlider.GetComponent<Slider>();
        leftSlider.value = 0;
        Slider rightSlider = torqueRightSlider.GetComponent<Slider>();
        float value= rightSlider.value;
        clickTimer = 0;
        torque = 1000 * value;
    }
    public void TorqueLeftButton()
    {
        isTorqueLeft = !isTorqueLeft;
        if (isTorqueLeft)
        {
            torque = 300;
            isTorqueRight = false;
        }
        else
        {
            torque = 10;
        }
    }
    public void TorqueRightButton()
    {
        
        isTorqueRight = !isTorqueRight;
        if (isTorqueRight)
        {
            torque = -300;
            isTorqueLeft = false;
        }
        else
        {
            torque = 10;
        }
    }
    #endregion
    public void ThrowBall()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");

        if (ball != null)
        {
            SpawnTheBall();
        }
    }
    void Update()
    {
        //Tracking the position of input (finger on phone, mouse on computer)
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos2D = new Vector2(mousePos.x, mousePos.y);

        hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (Input.GetMouseButton(0))
        {
            clickTimer += Time.deltaTime;
            if(clickTimer > holdTime)
            {
                SpawnTheBall();
                clickTimer = -5;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            clickTimer = 0;
        }
    }
    void Awake()
    {
        LevelScore.score = 0;
    }
}
