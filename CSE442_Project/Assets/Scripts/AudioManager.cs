using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>{

    private AudioSource source;
    public AudioClip Door;
    public AudioClip Puzzle;
    public AudioClip Plate;
    public AudioClip key;
    public AudioClip Chest;
    public AudioClip Book, Candles, Treasure;
    
    
    // Use this for initialization
    void Start () {
        source = this.GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
	}
	


    public void PlayAudio(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
    public void PlayAudio(AudioName type)
    {

        switch (type)
        {
            case AudioName.Door:
                source.PlayOneShot(Door);
                break;
            case AudioName.Puzzle:
                source.PlayOneShot(Puzzle);
                break;
            case AudioName.Plate:
                source.PlayOneShot(Plate);
                break;
            case AudioName.Key:
                source.PlayOneShot(key);
                break;
            case AudioName.Chest:
                source.PlayOneShot(Chest);
                break;
            case AudioName.Book:
                source.PlayOneShot(Book);
                break;
            case AudioName.Candles:
                source.PlayOneShot(Candles);
                break;
            case AudioName.Treasure:
                source.PlayOneShot(Treasure);
                break;
        }

    }
}
public enum AudioName
{
    Door, Puzzle, Plate, Key, Chest, Book, Candles, Treasure
}
