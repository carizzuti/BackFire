using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            gameObject.GetComponent<SpriteRenderer>().color = Color.clear;

            if (gameObject.tag == "Gold")
            {
                GameController.instance.AddCollectedItems(1);
            }
            else if (gameObject.tag == "Silver")
            {
                GameController.instance.AddCollectedItems(0);
            }
            else if (gameObject.tag == "Key")
            {
                GameController.instance.AddCollectedItems(2);
            }

            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
