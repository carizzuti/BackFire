using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockableDoor : MoveableObject
{
    private Animator animator;
    private AudioSource audioSource;

    [SerializeField] private AudioClip unlockAudio, openAudio, winAudio;

    public bool allKeysCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent <AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockDoor()
    {
        allKeysCollected = true;
        audioSource.clip = unlockAudio;
        audioSource.Play();
        animator.SetTrigger("Unlock");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && allKeysCollected)
        {
            StartCoroutine(OpenDoorandCompleteLevel());
        }
    }

    IEnumerator OpenDoorandCompleteLevel()
    {
        audioSource.clip = openAudio;
        audioSource.Play();
        animator.SetTrigger("Open");

        yield return new WaitForSeconds(1);

        audioSource.clip = winAudio;
        audioSource.Play();

        TimerController.instance.EndTimer();
    }
}
