using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveBackgroundHandler : MonoBehaviour
{
    [SerializeField] GameObject[] backgroundSettings;
    [SerializeField] GameObject canvasBackground;
    int randomNumber;
    
    void Start()
    {
        randomNumber = Random.Range(0, backgroundSettings.Length);
        backgroundSettings[randomNumber].SetActive(true);
        //if (randomNumber % 2 == 0)
        //{
        //}
            canvasBackground.SetActive(true);
    }
}
