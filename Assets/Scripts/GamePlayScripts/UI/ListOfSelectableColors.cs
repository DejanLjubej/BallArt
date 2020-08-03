using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListOfSelectableColors : MonoBehaviour
{
    public Image selectableImage;
    
    // Start is called before the first frame update
    void Start()
    {
        DisplayColorsToChoose();
    }

    // Update is called once per frame

    public void DisplayColorsToChoose()
    {
        for (int i = 0; i < UpgradesList.colorField.Length; i++)
        {
            string isSelectableColor = "SelectableColor" + i + "(Clone)";
            if (PlayerPrefs.GetInt(isSelectableColor, 0) == 1)
            {
                selectableImage.color = UpgradesList.colorField[i];
                selectableImage.name = "Color" + i;
                Instantiate(selectableImage, transform);   
            }
        }
    }
}
