/****************************************************************************
* File Name: AudioManager.cs
* Author: Bishep Clous
* DigiPen Email: bishep.clous@digipen.edu
* Course: Game Projects
*
* Description: Holds the lists of sound effects and music to be played on the
* different levels
*
****************************************************************************/

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music")]
    public List<AudioSource> Music = new List<AudioSource>();

    [Header("SFX")]
    public List<AudioSource> SFX = new List<AudioSource>();

    private bool introScreen = false;

    private void Awake()
    {
        //If there is not another gameObject of this name, make this gameObject permanent, if there is destroy this and keep the other
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //plays title screen music if on title, stops otherwise, no clue where the other music is handled
        if (SceneManager.GetActiveScene().name == "Intro Screen")
        {
            Music[5].Play();
            introScreen = true;
        }
    }

    //Checks if the level is not intro and stops intro music
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Intro Screen" && !introScreen)
        {
            Music[5].Play();
            introScreen = true;
        }
        else if (SceneManager.GetActiveScene().name != "Intro Screen")
        {
            Music[5].Stop();
            introScreen = false;
        }
    }
}
