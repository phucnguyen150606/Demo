using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public void SetMaterVolume(float Level)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(Level) * 20f);
    }

    public void SetSoundFXVloume(float Level)
    {
        audioMixer.SetFloat("SoundFXVolume", Mathf.Log10(Level) * 20f);

    }

    public void SetMusicVolume(float Level)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(Level) * 20f);
    }
}
