using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class AudioManager : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource music, sfx;
    public static AudioManager i;
    const string MIXER_MUSIC = "MusicVolume", MIXER_SFX = "SFXVolume";

    void Awake()
    {
        if (i == null)
        {
            i = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
    }
    public void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
    }
    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
    public void PlaySFX(string clipName)
    {
        sfx.PlayOneShot(AudioClips.i.clips[clipName]);
    }
}