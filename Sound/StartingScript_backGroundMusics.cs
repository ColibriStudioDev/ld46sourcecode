using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StartingScript_backGroundMusics : MonoBehaviour
{
    //public variables
    [Header("Null = Instantiate an AudioSource")]
    [SerializeField]
    private AudioSource source;

    //Private Variable
    public AudioClip[] musicLists;
    private  int previous;
    private  int random () {
        return Random.Range(0, musicLists.Length);
    }



    void Awake()
    {
        if(source == null)
        {
            GameObject temp = new GameObject();
            temp.AddComponent<AudioSource>();
            source = temp.GetComponent<AudioSource>();
            temp.name = "StartingScript_AudioSource";
        }

     
            previous = random();
            source.clip = musicLists[previous];
            source.Play();



    }


    void Update()
    {
        if(source.isPlaying == false)
        {
            NextBackGroundMusic();
        }
    }

    //Go to the next music
    public void NextBackGroundMusic()
    {
        int temp = random();
        while (temp == previous)
        {
            temp = random();
        }
        previous = temp;
        source.clip = musicLists[previous];
        source.Play();
    }
}
