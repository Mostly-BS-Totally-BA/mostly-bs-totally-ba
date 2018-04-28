using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Volume : MonoBehaviour {

    public float volValAll { get; private set; }
    public float volValMusic { get; private set; }
    public float volValSFX { get; private set; }
    [SerializeField]
    private Slider volSliderAll;
    [SerializeField]
    private Slider volSliderMusic;
    [SerializeField]
    private Slider volSliderSFX;

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
        volValAll = volSliderAll.value;
     }

    public void OnAllValueChanged()
    {
        //volSliderMusic = GetComponent<Slider>();
        //volSliderSFX = GetComponent<Slider>();
        volValAll = volSliderAll.value / 10;
        mmgr.SetMusicVolume(volValAll);
        amgr.SetEffectsVolume(volValAll);

        volSliderMusic.value = volValAll * 10;
        volSliderSFX.value = volValAll * 10;
    }

    public void OnMusicValueChanged()
    {
        volValMusic = volSliderMusic.value / 10;
        mmgr.SetMusicVolume(volValMusic);
    }

    public void OnSFXValueChanged()
    {
        volValSFX = volSliderSFX.value / 10;
        amgr.SetEffectsVolume(volValSFX);
    }

    public void SetSliders()
    {
        volSliderAll.value = volValAll * 10;
        volSliderMusic.value = volValMusic * 10;
        volSliderSFX.value = volValSFX * 10;
    }
}
