using UnityEngine;
using AYellowpaper.SerializedCollections;
public class AudioClips : MonoBehaviour
{
    public static AudioClips i;
    public SerializedDictionary<string, AudioClip> clips = new SerializedDictionary<string, AudioClip>();
    void Awake()
    {
        i = this;
    }
}