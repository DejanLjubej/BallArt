using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IsColorLocked : MonoBehaviour
{

    public Button isColorLocked;
    public Image imageForColor;
    public int price;
    // Start is called before the first frame update
    void Start()
    {
        ShowColors();
    }

    void ShowColors()
    {
        if(isColorLocked != null)
        {
            if (PlayerPrefs.GetInt("Selectable"+this.name, 0) != 0)
            {
                isColorLocked.gameObject.SetActive(false);
            }
            else
            {
                isColorLocked.gameObject.SetActive(true);
                isColorLocked.GetComponentInChildren<Text>().text = price.ToString() + "CF";
            }
        }
    }
    public void UnlockColor()
    {
        if (PlayerPrefs.GetInt("PlayerCurrentMoney", 0) >= price)
        {
            PlayerPrefs.SetInt("Selectable"+this.name, 1);
            PlayerPrefs.SetInt("PlayerCurrentMoney", PlayerPrefs.GetInt("PlayerCurrentMoney", 0) - price);
        }
        ShowColors();
    }

    public void changeColorOfTube(Color color)
    {
        imageForColor.color = color; 
    }
}
