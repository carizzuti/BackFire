using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MoveableObject
{
    private AudioSource audioSource;

    [SerializeField] private Player player;
    [SerializeField] private AudioClip falling;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Falling");
            audioSource.Play();
            player.transform.position = this.transform.position;
            player.PlayerFall();
        }
    }
}
