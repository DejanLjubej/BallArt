using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class MustHaveParameterValues : MonoBehaviour
{
    private string gameId = "3734767";
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, true);
        PlayerPrefs.SetInt("SelectableColor0(Clone)", 1);
    }

}
