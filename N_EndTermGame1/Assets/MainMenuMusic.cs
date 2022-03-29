using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public AudioSource music;
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        music.clip = clips[0];
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        

       /* 
        if(!music.isPlaying)
        {
            int index = Random.Range(0, clips.Length);
            music.clip = clips[index];
        }*/
       

    }
}
