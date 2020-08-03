using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMotor : MonoBehaviour
{
    public Splatter colorSplash;

    PlayerStats _playerStats;

    Vector2 _direction;
    float _force;
    float _torque;

    bool _lastbounce = false;

    [SerializeField]
    float _ballDivider = 2;
    float _numberOfBounces = 1;
    bool lastBall = false;
    public static int numberOfActiveBalls =0;
    SoundManager _soundManager;

    void Start()
    {
        lastBall = false;
        _soundManager = FindObjectOfType<SoundManager>();
        _force = SpawnBall.power;
        _torque = SpawnBall.spin;
        _direction = SpawnBall.moveDirection;

        this.GetComponent<Rigidbody2D>().AddForce(_direction * _force);
        _playerStats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();

        if (_playerStats.currentNumberOfBalls <= 0)
        {
            lastBall = true;
        }
    }

    
    void OnTriggerEnter2D(Collider2D collider)
    {
        Instantiate(colorSplash, this.transform.position, Quaternion.identity);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(_playerStats.currentNumberOfBalls > 0)
        {
            lastBall = false;
        }
        if (col.gameObject.tag != "Obstacle")
        {
            Points.hitsInARow = 0;
        }
        colorSplash.SetColorOfSplat(this.gameObject.GetComponent<SpriteRenderer>().color);

        Splatter splat = (Splatter)Instantiate(colorSplash, this.transform.position, Quaternion.identity);
        this.transform.localScale = this.transform.localScale / _ballDivider;
        if (this.transform.localScale.x < 0.1)
        {
            splat.transform.localScale = splat.transform.localScale / 2;
            if (_lastbounce)
            {
                
                this.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                _playerStats.BallStopped();

                if (_playerStats.currentNumberOfBallsLeft <= 0)
                {
                    _playerStats.GameOver();
                }
            }
            _lastbounce = true;
        }
        else
        {
            splat.transform.localScale = splat.transform.localScale / _numberOfBounces;

        }
        _numberOfBounces += (_ballDivider / 2);
        _soundManager.Play();
    }

    public void AddForceAndTorque(Vector2 directionOfPointer, float torque, float force)
    {
        this.GetComponent<Rigidbody2D>().AddForce(directionOfPointer * force);
        this.GetComponent<Rigidbody2D>().AddTorque(torque, ForceMode2D.Impulse);
    }
}
