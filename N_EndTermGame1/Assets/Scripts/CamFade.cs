using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFade : MonoBehaviour
{
    public GameObject Fader;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = Fader.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("FadeIn", true);
    }
}
