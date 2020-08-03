using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class MenuButtons : MonoBehaviour
{
    public GameObject SettingsPanel;

    bool _areSettingsOpen;
    void Start()
    {
        _areSettingsOpen = false;
        if(SettingsPanel != null)
        {
            SettingsPanel.SetActive(false);
        }
    }
    public void Refresh()
    {
        PlayerPrefs.DeleteAll();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void UpgradesButton()
    {
        SceneManager.LoadScene("UpgradeSelect");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SettingsButton()
    {
        if(SettingsPanel != null)
        {
            _areSettingsOpen = !_areSettingsOpen;
            SettingsPanel.SetActive(_areSettingsOpen);
        }
    }

}
