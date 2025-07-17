using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;
    //[SerializeField] private Slider MusicVolumeSlider;

    public static SoundMixerScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if (PlayerPrefs.HasKey("Master"))
        {
            LoadVolumeSettings();
        }
        else
        {
            SetMasterVolume();
            SetSoundFXVolume();
        }
    }


    public void SetMasterVolume()
    {
        float Level = masterVolumeSlider.value;
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(Level) * 20f);
        PlayerPrefs.SetFloat("Master", Level);
    }

    public void SetSoundFXVolume()
    {
        float Level = SFXVolumeSlider.value;
        audioMixer.SetFloat("SoundFXVolume", Mathf.Log10(Level) * 20f);
        PlayerPrefs.SetFloat("SoundFX", Level);

    }

    //public void SetMusicVolume()
    //{
    //    float Level = MusicVolumeSlider.value;

    //    audioMixer.SetFloat("MusicVolume", Mathf.Log10(Level) * 20f);
    //    PlayerPrefs.SetFloat("MusicVolume", Level);
    //}

    public void LoadVolumeSettings()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("Master");
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("SoundFX");

        SetMasterVolume();
        SetSoundFXVolume();

    }
}
