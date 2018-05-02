using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Volume : MonoBehaviour {

    public float volValAll { get; private set; }
    public float volValMusic { get; private set; }
    public float volValSFX { get; private set; }


    private MusicManager mmgr;
    private AudioManager amgr;

    void Awake(){
        //SetSliders();
    }

    void Start()
    {
        //volSliderAll = GetComponent<Slider>();
        volValAll = 0.5f;
        volValMusic = 0.5f;
        volValSFX = 0.5f;
        mmgr = MusicManager.Instance;
        amgr = AudioManager.Instance;
    }

    void Update()
    {
        //volValAll = volSliderAll.value;
     }

    public void SetAllValueChanged(float val)
    {
        volValAll = val;
        mmgr.SetMusicVolume(volValAll);
        amgr.SetEffectsVolume(volValAll);
    }

    public void SetMusicValueChanged(float val)
    {
        volValMusic = val;
        mmgr.SetMusicVolume(volValMusic);
    }

    public void SetSFXValueChanged(float val)
    {
        volValSFX = val;
        amgr.SetEffectsVolume(volValSFX);
    }
}
