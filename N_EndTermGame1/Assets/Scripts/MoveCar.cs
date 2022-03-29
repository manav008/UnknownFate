using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCar : MonoBehaviour
{
   
    public Transform Point1;
    public Transform Point2;
    public float speed = 10;

    public ParentCm camtime;
    // private Rigidbody rb;
    public GameObject Fader;
    public Animator animator;
    public float TimetoFadeOut = 32f;

    public AudioSource Source;
    public AudioClip Clip;
    public AudioClip CarCrash;
    public GameObject MainCamera;

    public float LoadMainLevel = 5f;
    public LoadSceneAsnc StartLevel;


    private void Start()
    {
       // rb = GetComponent<Rigidbody>();
       animator = Fader.GetComponent<Animator>();
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;
        transform.position =  Vector3.MoveTowards(transform.localPosition, Point2.localPosition, Time.deltaTime * step);
        //rb.AddForce(speed * Time.deltaTime * transform.forward);
    }

    private void Update()
    {
        if(camtime.TimeToParent <= 0)
        {
            //camtime.TimeToParent = 20;
            Source.clip = Clip;
            Source.volume = 0.1f;
            Source.Play();
            speed = 1000;
        }
          
        if(TimetoFadeOut > 0)
        {
            TimetoFadeOut -= Time.deltaTime;
        }
        else
        {
            //TimetoFadeOut = 32;           
            animator.SetBool("FadeOut", true);
            animator.SetBool("FadeIn", false);
            if(Source.isPlaying)
            {
                Source.Stop();                
            }
            Source.clip = CarCrash;
            Source.Play();

            Source = MainCamera.GetComponent<AudioSource>();
            Source.Stop();
        }

        if(TimetoFadeOut <=0)
        {
            if (LoadMainLevel > 0)
            {
                LoadMainLevel -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
        
    }
}
