using UnityEngine.Audio;
using UnityEngine;
using System; 
using System.Collections.Generic; 




[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private AudioSource _source;



    void Awake()
    {
        _source = GetComponent<AudioSource>();
      

    }

    private void Update()
    {
        _source.volume = HUD_Update.globalVolume;
        if (HUD_Update.isMuted) _source.volume = 0;
    }


    public void PlayMusic(string name)
    {
        Sound s = Array.Find<Sound>(sounds, Sound => Sound.name == name);
        if(s==null)
        {
            return;
        }
        _source.clip = s.clip;
        _source.Play();
    }


}
