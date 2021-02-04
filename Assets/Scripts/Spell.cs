using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private Rigidbody2D rb;
    private Player player;
    private AudioSource audioSource;

    [SerializeField]
    private float speed;

    [SerializeField]
    private AudioClip fireballCast, fireballHit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
        audioSource = GetComponent<AudioSource>();
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

        audioSource.clip = fireballCast;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 shootDirection = player.GetDirection();

        rb.velocity = shootDirection * speed;

        if (shootDirection == Vector2.up)
        {
            transform.localEulerAngles = new Vector3(0, 0, 180);
        }
        else if (shootDirection == Vector2.left)
        {
            transform.localEulerAngles = new Vector3(0, 0, -90);
        }
        else if (shootDirection == Vector2.right)
        {
            transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        else
        {
            transform.localEulerAngles = Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            speed = 0;
            audioSource.Stop();

            audioSource.clip = fireballHit;
            audioSource.Play();
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            Destroy(gameObject, 1f);
        }        
    }
}
