using UnityEngine;
using UnityEngine.Rendering.UI;

public class AudioManager_Script : MonoBehaviour
{
    public AudioSource EffectAudioSource;
    public AudioSource MusicAudioSource;
    public AudioClip FlapSound;
    public AudioClip PointSound;
    public AudioClip DieSound;
    public AudioClip MusicSound;

    private static AudioManager_Script instance;
    public static AudioManager_Script Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<AudioManager_Script>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("AudioManager");
                    instance = obj.AddComponent<AudioManager_Script>();
                }
            }
            return instance;
        }
    }
    void Awake()
    {
        PlayMusicSound();
    }

    public void PlayMusicSound()
    {
        MusicAudioSource.clip = MusicSound;
        MusicAudioSource.Play();
    }
    public void PlayFlapSound()
    {
        EffectAudioSource.PlayOneShot(FlapSound);
    }
    public void PlayPointSound()
    {
        EffectAudioSource.PlayOneShot(PointSound);
    }
    public void PlayDieSound()
    {
        EffectAudioSource.PlayOneShot(DieSound);
    }
}
