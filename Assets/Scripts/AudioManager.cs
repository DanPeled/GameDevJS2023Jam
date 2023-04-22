using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private Slider masterSlider, musicSlider, sfxSlider;
    public AudioMixer mixer;
    public AudioSource music, sfx;
    public static AudioManager i;
    const string MIXER_MUSIC = "MusicVolume", MIXER_SFX = "SFXVolume", MIXER_MASTER = "MasterVolume";

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
    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume") && PlayerPrefs.HasKey("MasterVolume") && PlayerPrefs.HasKey("SFXVolume"))
        {

        }
    }
    public void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    public void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }
    public void PlaySFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }
    public void PlaySFX(string clipName)
    {
        sfx.PlayOneShot(AudioClips.i.clips[clipName]);
    }
    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        SetMasterVolume(volume);
    }
    public void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        SetMusicVolume(volume);
    }
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        SetSFXVolume(volume);
    }
    private void LoadVolume()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1);

        SetMasterVolume();
    }
}