using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>{

    private AudioSource _audSrc;
    [SerializeField]
    private AudioClip Door;
    [SerializeField]
    private AudioClip Puzzle;
    [SerializeField]
    private AudioClip Plate;
    [SerializeField]
    private AudioClip Key;
    [SerializeField]
    private AudioClip Chest;
    [SerializeField]
    private AudioClip Book, Candles, Treasure;
    [SerializeField]
    private AudioClip Potion;
    [SerializeField]
    private AudioClip PlayerDMG;
    [SerializeField]
    private AudioClip PlayerDeath;
    [SerializeField]
    private AudioClip PlayerAttack;

    // Use this for initialization
    void Start () {
        _audSrc = this.GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
	}
	
    public void SetEffectsVolume(float val){
        _audSrc.volume = val;
    }

    public void PlayAudio(AudioClip clip)
    {
        _audSrc.PlayOneShot(clip);
    }
    public void PlayAudio(AudioName type)
    {

        switch (type)
        {
            case AudioName.Door:
                _audSrc.PlayOneShot(Door);
                break;
            case AudioName.Puzzle:
                _audSrc.PlayOneShot(Puzzle);
                break;
            case AudioName.Plate:
                _audSrc.PlayOneShot(Plate);
                break;
            case AudioName.Key:
                _audSrc.PlayOneShot(Key);
                break;
            case AudioName.Chest:
                _audSrc.PlayOneShot(Chest);
                break;
            case AudioName.Book:
                _audSrc.PlayOneShot(Book);
                break;
            case AudioName.Candles:
                _audSrc.PlayOneShot(Candles);
                break;
            case AudioName.Treasure:
                _audSrc.PlayOneShot(Treasure);
                break;
            case AudioName.PotionGet:
                _audSrc.PlayOneShot(Potion);
                break;
            case AudioName.PotionDrink:
                _audSrc.PlayOneShot(Potion);
                break;
            case AudioName.PlayerDMG:
                _audSrc.PlayOneShot(PlayerDMG);
                break;
            case AudioName.PlayerDeath:
                _audSrc.PlayOneShot(PlayerDeath);
                break;
            case AudioName.PlayerAttack:
                _audSrc.PlayOneShot(PlayerAttack);
                break;
        }

    }
}
public enum AudioName
{
    Door, Puzzle, Plate, Key, Chest, Book, Candles, Treasure, PotionGet, PotionDrink, PlayerDMG, PlayerDeath, PlayerAttack
}
