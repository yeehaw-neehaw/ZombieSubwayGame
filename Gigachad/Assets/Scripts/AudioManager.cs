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

    private void Update()
    {
        if (SceneManager.GetSceneByName("Level Designer Type Level 1").Equals(true))
        {
            Music[0].Play();
        }
    }
}
