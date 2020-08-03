using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class AdjustMusicVolume : MonoBehaviour
{
    MusicManager _musicManager;
    Scrollbar _scrollBar;

    float _currentMusicVolume;
    
        // Start is called before the first frame update
    void Start()
    {
        _scrollBar= this.gameObject.GetComponent<Scrollbar>();
        _musicManager = FindObjectOfType<MusicManager>();
        if (_musicManager!=null) {
            _currentMusicVolume = _musicManager.CurrentMusicVolume();
            _scrollBar.value = _currentMusicVolume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float valueofScrollbar = _scrollBar.value;
        if(_musicManager != null)
        {
            _musicManager.MusicVolumeAdjustment(valueofScrollbar);
        }
    }
}
