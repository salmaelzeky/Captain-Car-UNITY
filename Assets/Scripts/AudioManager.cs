using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {

        if(instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;

            if (GameOverScreen.GameOver == true || PauseMenu.GameIsPaused == true)
            {
                s.source.pitch = s.pitch -  1.5f;

            }
            else
            {
                s.source.pitch = s.pitch;

            }
        }
    }

 
    void Start()
    {
        Play("Theme");
       
    }

    public void Play(string name)
    {
       Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
            
        s.source.Play();
    }
}
