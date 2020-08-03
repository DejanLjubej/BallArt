using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyManagement : MonoBehaviour
{

    public int playerCurrentMoney = 150;
    Text currentMoneyText;
    // Start is called before the first frame update
    void Start()
    {
        currentMoneyText = this.GetComponent<Text>();
        PlayerPrefs.GetInt("PlayerCurrentMoney", playerCurrentMoney);
    }

    // Update is called once per frame
    void Update()
    {
        currentMoneyText.text = "CF: " + PlayerPrefs.GetInt("PlayerCurrentMoney", 0);
    }
}
