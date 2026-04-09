using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music")]
    public AudioSource MainMenu;
    public AudioSource Subway;
    public AudioSource Ambient;
    public AudioSource Battle;

    [Header("SFX")]
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public AudioSource audioSource5;
    public AudioSource audioSource6;
    public AudioSource audioSource7;
    public AudioSource audioSource8;
    public AudioSource audioSource9;
    public AudioSource audioSource10;
    public AudioSource audioSource11;
    public AudioSource audioSource12;
    public AudioSource audioSource13;
    public AudioSource audioSource14;
    public AudioSource audioSource15;
    public AudioSource audioSource16;
    public AudioSource audioSource17;
    public AudioSource audioSource18;
    public AudioSource audioSource19;
    public AudioSource audioSource20;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
