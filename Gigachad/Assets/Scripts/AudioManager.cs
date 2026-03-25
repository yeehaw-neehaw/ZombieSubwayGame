using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip gunShootSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gunShootSound = Resources.Load<AudioClip>("Gun_1_Shoot");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "gunShoot":
                audioSource.PlayOneShot(gunShootSound);
                break;
        }
    }
}
