using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MoveableObject
{
    [SerializeField]
    private int health;

    private Animator animator;
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip objectOpen, objectBreak, objectDestroy;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("Health", health);

        audioSource = GetComponent<AudioSource>();
        NewScale();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (health == 3)
        {
            audioSource.clip = objectOpen;
            audioSource.Play();
        }
        else if (health == 2)
        {
            audioSource.clip = objectBreak;
            audioSource.Play();
        }
        else if (health == 1)
        {
            audioSource.clip = objectDestroy;
            audioSource.Play();
        }

        health -= 1;
        animator.SetInteger("Health", health);

        if (health == 0)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
