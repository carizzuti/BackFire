using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MoveableObject
{
    private Animator animator;
    private AudioSource myAudioSource;
    private bool isOpen = false;

    public bool canOpen = false;
    
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
        if (collision.gameObject.tag == "Player" && !isOpen && canOpen)
        {
            animator.SetTrigger("Open");
            myAudioSource.Play();
            isOpen = true;
        }
    }
}
