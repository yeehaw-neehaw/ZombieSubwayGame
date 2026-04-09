using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public List<AudioClip> sources = new List<AudioClip>();
}
