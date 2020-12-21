using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;
    private AudioSource myAudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Open");
            myAudioSource.Play();
        }
    }
}
