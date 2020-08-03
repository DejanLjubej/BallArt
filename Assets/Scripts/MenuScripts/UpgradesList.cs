using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesList : MonoBehaviour
{
    public GridLayoutGroup gridGroup;
    public Image colorImage;
    public static Color[] colorField = { Color.black, Color.red, Color.green, Color.blue, Color.yellow, Color.cyan, Color.magenta, Color.white};
    public int[] colorPrice = new int[colorField.Length];
    void Start()
    {
        PlayerPrefs.SetInt("SelectableColor0(Clone)", 1);
        for (int i = 0; i < colorField.Length; i++)
        {
            if(colorImage != null)
            {
                colorImage.name = "Color"+i;
                colorImage.gameObject.GetComponent<IsColorLocked>().price=colorPrice[i];
                Image crntImage=(Image)Instantiate(colorImage, transform);
                IsColorLocked scriptOnImage= crntImage.GetComponent<IsColorLocked>();
                scriptOnImage.changeColorOfTube(colorField[i]);
            }
        }
    }
}
