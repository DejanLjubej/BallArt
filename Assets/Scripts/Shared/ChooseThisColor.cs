using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseThisColor : MonoBehaviour
{
    public static int chosenColorNumber;
    int numberOfThisObject;
    string nameNumber;
    void Start()
    {
        nameNumber = this.name.Replace("Color", "").Replace("(Clone)", "").Trim();
        int.TryParse(nameNumber, out numberOfThisObject);
    }

    void Update() {
        if(numberOfThisObject != chosenColorNumber)
        {
            this.gameObject.GetComponentInChildren<Button>().interactable = true;
        }
        else
        {
            this.gameObject.GetComponentInChildren<Button>().interactable = false;
        }
    }
    public void UseThisColor()
    {
        int.TryParse( nameNumber, out chosenColorNumber);
    }
}
