using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnowToJungle : MonoBehaviour
{
    public GameObject MaincCam;
    public AudioSource Source;
    public AudioClip jungle;
    public AudioClip Snow;
    // Start is called before the first frame update
    void Start()
    {
        Source = MaincCam.GetComponent<AudioSource>();
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Decreasevolume());
            
        }     
    }
    private void Update()
    {
        if(Source.volume == 0)
        {
            while(Source.volume < 1)
            {
                Source.clip = jungle;
                Source.Play();
                StartCoroutine(IncreaseVolume());
            }
            return;
        }
    }

    private IEnumerator Decreasevolume()
    {
        while(Source.volume > 0)
        {
            Source.volume -= 0.01f;          
            yield return null; 
        }
    }

    private IEnumerator IncreaseVolume()
    {
        while(Source.volume < 1)
        {
            Source.volume += 0.01f;          
            yield return null;        
        }
    }
}
