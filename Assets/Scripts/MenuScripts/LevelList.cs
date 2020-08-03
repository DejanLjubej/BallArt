using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelList : MonoBehaviour
{

    public GridLayoutGroup gridGroup;
    public Button levelButton;
    Text levelNumber;
    int numberOfLevel;
    [SerializeField]
    int numberOfButtons = 0;

    void Start()
    {

        numberOfButtons = SceneManager.sceneCountInBuildSettings-3;
        StartCoroutine(LazyLevelLoad());
        //Text[] texts = levelButton.GetComponentsInChildren<Text>();

        //foreach (Text text in texts)
        //{
        //    if (text.name == "LevelNumber")
        //    {
        //        levelNumber = text;
        //    }
        //}

        ////gridGroup = this.gameObject.GetComponent<GridLayoutGroup>();

        //for (int i = 0; i < numberOfButtons; i++)
        //{
        //    numberOfLevel = i;
        //    levelNumber.text = (numberOfLevel + 1).ToString();
        //    levelButton.name = "Level" + (numberOfLevel + 1).ToString();
        //    Instantiate(levelButton, transform);
        //}

    }

    IEnumerator LazyLevelLoad()
    {
        Text[] texts = levelButton.GetComponentsInChildren<Text>();

        foreach (Text text in texts)
        {
            if (text.name == "LevelNumber")
            {
                levelNumber = text;
            }
        }

        //gridGroup = this.gameObject.GetComponent<GridLayoutGroup>();

        for (int i = 0; i < numberOfButtons; i++)
        {
            numberOfLevel = i;
            levelNumber.text = (numberOfLevel + 1).ToString();
            levelButton.name = "Level" + (numberOfLevel + 1).ToString();
            Instantiate(levelButton, transform);
            if(i%2 == 0)
            {
                yield return new WaitForSecondsRealtime(0.1f);
            }
        }
    }
}
