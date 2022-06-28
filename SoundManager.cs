using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip newGame;
    [SerializeField] private AudioClip die;
    [SerializeField] private AudioClip game;

    public static SoundManager Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioClip Newgame
    {
        get
        {
            return newGame;
        }
    }

    public AudioClip Die
    {
        get
        {
            return die;
        }
    }

    public AudioClip GameOver
    {
        get
        {
            return game;
        }
    }
}
