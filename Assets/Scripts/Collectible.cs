﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public static Collectible instance;

    private AudioSource audioSource;
    private GameObject[] getCountGold, getCountSilver, getCountKeys;
    private int countGold, countSilver, countKeys;
    private int goldPickedUp, silverPickedUp, keysPickedUp;

    [SerializeField] private Text goldInventory, silverInventory, keyInventory;
    [SerializeField] private Chest chest;
    [SerializeField] private UnlockableDoor door;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        getCountGold = GameObject.FindGameObjectsWithTag("Gold");
        countGold = getCountGold.Length;
        goldInventory.text = goldPickedUp + " / " + countGold;

        getCountSilver = GameObject.FindGameObjectsWithTag("Silver");
        countSilver = getCountSilver.Length;
        silverInventory.text = silverPickedUp + " / " + countSilver;

        getCountKeys = GameObject.FindGameObjectsWithTag("Key");
        countKeys = getCountKeys.Length;
        keyInventory.text = keysPickedUp + " / " + countKeys;

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
            audioSource.Play();
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

            if (gameObject.tag == "Gold")
            {
                goldPickedUp += 1;
                goldInventory.text = goldPickedUp + " / " + countGold;
            }
            else if (gameObject.tag == "Silver")
            {
                silverPickedUp += 1;
                silverInventory.text = silverPickedUp + " / " + countSilver;
            }
            else if (gameObject.tag == "Key")
            {
                keysPickedUp += 1;
                keyInventory.text = keysPickedUp + " / " + countKeys;

                if (getCountKeys.Length == keysPickedUp)
                {
                    door.UnlockDoor();
                }

                if (keysPickedUp > 0)
                {
                    chest.canOpen = true;
                }
            }

            Destroy(gameObject, audioSource.clip.length);
        }
    }

    public int GetGoldCount()
    {
        return goldPickedUp;
    }

    public int GetSilverCount()
    {
        return silverPickedUp;
    }
}
