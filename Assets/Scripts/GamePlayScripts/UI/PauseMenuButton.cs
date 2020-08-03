using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenuButton : MonoBehaviour
{
    public GameObject pausePanel;

    public void PauseMenu()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            this.gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            this.gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
