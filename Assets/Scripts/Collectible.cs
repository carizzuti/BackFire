using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private AudioSource audioSource;

    private float idleOffset;

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float height = 0.5f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        IdleEffect();
    }

    private void IdleEffect()
    {
       Vector3 pos = transform.position;
       float newY = Mathf.Sin(Time.time * speed);
       transform.position = new Vector3(pos.x, newY) * height;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Play();
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            Destroy(gameObject, audioSource.clip.length);
        }
    }
}
