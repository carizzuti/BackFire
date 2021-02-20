using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private int goldCoinsCollected, silverCoinsCollected, keysCollected;
    private int goldCoinsTotal, silverCoinsTotal, keysTotal;
    private GameObject[] getCountGold, getCountSilver, getCountKeys;

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
        TimerController.instance.BeginTimer();

        getCountGold = GameObject.FindGameObjectsWithTag("Gold");
        goldCoinsTotal = getCountGold.Length;
        goldInventory.text = goldCoinsCollected + " / " + goldCoinsTotal;

        getCountSilver = GameObject.FindGameObjectsWithTag("Silver");
        silverCoinsTotal = getCountSilver.Length;
        silverInventory.text = silverCoinsCollected + " / " + silverCoinsTotal;

        getCountKeys = GameObject.FindGameObjectsWithTag("Key");
        keysTotal = getCountKeys.Length;
        keyInventory.text = keysCollected + " / " + keysTotal;
    }

    public void AddCollectedItems(int type)
    {
        if (type == 0) // silver
        {
            silverCoinsCollected++;
            silverInventory.text = silverCoinsCollected + " / " + silverCoinsTotal;

        }
        else if (type == 1) // gold
        {
            goldCoinsCollected++;
            goldInventory.text = goldCoinsCollected + " / " + goldCoinsTotal;
        }
        else if (type == 2) // key
        {
            keysCollected++;
            keyInventory.text = keysCollected + " / " + keysTotal;

            if (keysCollected == keysTotal)
            {
                door.UnlockDoor();
            }
            else if (keysCollected > 0)
            {
                chest.canOpen = true;
            }
        }
    }

    public void AddAvailableItems(int type)
    {
        if (type == 0) // silver
        {
            silverCoinsTotal++;
        }
        else if (type == 1) // gold
        {
            goldCoinsTotal++;
        }
        else if (type == 2) // key
        {
            keysTotal++;
        }
    }

    public int GetSilverCollected()
    {
        return silverCoinsCollected;
    }

    public int GetGoldCollected()
    {
        return goldCoinsCollected;
    }

    public int GetKeysCollected()
    {
        return keysCollected;
    }

    public int GetSilverAvailable()
    {
        return silverCoinsTotal;
    }

    public int GetGoldAvailable()
    {
        return goldCoinsTotal;
    }

    public int GetKeysAvailable()
    {
        return keysTotal;
    }

}
