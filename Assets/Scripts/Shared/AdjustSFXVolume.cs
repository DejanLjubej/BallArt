using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AdjustSFXVolume : MonoBehaviour
{
    Scrollbar _scrollBar;
    SoundManager _soundManager;
    float _currentMusicVolume;

    void Start()
    {
        _scrollBar = this.gameObject.GetComponent<Scrollbar>();
        _soundManager = FindObjectOfType<SoundManager>();
        if (_soundManager != null)
        {
            _currentMusicVolume = _soundManager.CurrentMusicVolume();
            _scrollBar.value = _currentMusicVolume;
        }
    }

    void Update()
    {
        float valueofScrollbar = _scrollBar.value;
        if (_soundManager != null)
        {
            _soundManager.MusicVolumeAdjustment(valueofScrollbar);
        }
    }  
}
