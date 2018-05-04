using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>{

    private AudioSource _audSrc;
    [SerializeField]
    private AudioClip Intro;
    [SerializeField]
    private AudioClip MM;
    [SerializeField]
    private AudioClip L1;
    [SerializeField]
    private AudioClip L2;
    [SerializeField]
    private AudioClip L3;
    [SerializeField]
    private AudioClip L4;
    [SerializeField]
    private AudioClip B1;
    [SerializeField]
    private AudioClip B2;
    [SerializeField]
    private AudioClip B3;
    [SerializeField]
    private AudioClip B4;
    [SerializeField]
    private AudioClip End;
    
    
    // Use this for initialization
    void Start () {
        _audSrc = this.GetComponent<AudioSource>();
        //_audSrc = this.GetComponent();
        DontDestroyOnLoad(this.gameObject);
	}
	
    public void SetMusicVolume(float val){
        _audSrc.volume = val;
    }

    public void PlayAudio(AudioClip clip)
    {
        _audSrc.PlayOneShot(clip);
    }

    public void StopAudio()
    {
        _audSrc.Stop();
    }

    public void PauseAudio(){
        _audSrc.Pause();
    }

    public void PlayAudio(MusicName type)
    {
        switch (type)
        {
            case MusicName.Intro:
                _audSrc.PlayOneShot(Intro);
                break;
            case MusicName.MM:
                _audSrc.PlayOneShot(MM);
                break;
            case MusicName.L1:
                _audSrc.PlayOneShot(L1);
                break;
            case MusicName.L2:
                _audSrc.PlayOneShot(L2);
                break;
            case MusicName.L3:
                _audSrc.PlayOneShot(L3);
                break;
            case MusicName.L4:
                _audSrc.PlayOneShot(L4);
                break;
            case MusicName.B1:
                _audSrc.PlayOneShot(B1);
                break;
            case MusicName.B2:
                _audSrc.PlayOneShot(B2);
                break;
            case MusicName.B3:
                _audSrc.PlayOneShot(B3);
                break;
            case MusicName.B4:
                _audSrc.PlayOneShot(B4);
                break;
            case MusicName.End:
                _audSrc.PlayOneShot(End);
                break;
        }
    }
}
public enum MusicName
{
    Intro, MM, L1, L2, L3, L4, B1, B2, B3, B4, End
}
