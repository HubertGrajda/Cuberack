using UnityEngine;
using System;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager Instance;
    public AudioMixer master;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);


        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.outputAudioMixerGroup = sound.group;
        }
    }
    public void PlaySound(string name)
    {
        Sound s = Array.Find(Instance.sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }
    public void StopSound(string name)
    {
        Sound s = Array.Find(Instance.sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }
    public void MasterVolumeSlider(float volume)
    {
        master.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
    public void MusicVolumeSlider(float volume)
    {
        master.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }
    public void PlayerSoundsVolumeSlider(float volume)
    {
        master.SetFloat("PlayerVolume", Mathf.Log10(volume) * 20);
    }
    public void EnemyProjectilesSoundVolumeSlider(float volume)
    {
        master.SetFloat("EnemyVolume", Mathf.Log10(volume) * 20);
    }

}
