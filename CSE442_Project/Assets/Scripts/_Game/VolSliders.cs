using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolSliders : MonoBehaviour {

    [SerializeField]
    private Slider volSliderAll;
    [SerializeField]
    private Slider volSliderMusic;
    [SerializeField]
    private Slider volSliderSFX;

    private Volume _vol;
    private float val;

    private void Start()
    {
        //_vol = GameObject.Find("OptionsMenu").GetComponent<Volume>();
        _vol = GameObject.Find("audioManager").GetComponent<Volume>();
    }

    public void OnAllValueChanged()
    {
        val = volSliderAll.value / 10;
        _vol.SetAllValueChanged(val);
        _vol.SetMusicValueChanged(val);
        _vol.SetSFXValueChanged(val);
    }

    public void OnMusicValueChanged()
    {
        val = volSliderMusic.value / 10;
        _vol.SetMusicValueChanged(val);
    }

    public void OnSFXValueChanged()
    {
        val = volSliderSFX.value / 10;
        _vol.SetSFXValueChanged(val);
    }

    public void SetAllSlider(float val)
    {
        volSliderAll.value = val * 10;
    }

    public void SetMusicSlider(float val)
    {
        volSliderMusic.value = val * 10;
    }

    public void SetSFXSlider(float val)
    {
        volSliderSFX.value = val * 10;
    }
}
