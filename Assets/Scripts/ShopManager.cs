using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private int fireCost, iceCost, lightningCost;
    [SerializeField] private Text firePrice, icePrice, lightningPrice, firePurchasedText, icePurchasedText, lightningPurchasedText;
    [SerializeField] private Text buyAndActivateText;
    [SerializeField] private Text goldToSpend;

    private int spellSelected; // 0 = fire, 1 = ice, 2 = lightning

    // Start is called before the first frame update
    void Start()
    {
        firePrice.text = fireCost.ToString();
        icePrice.text = iceCost.ToString();
        lightningPrice.text = lightningCost.ToString();
        goldToSpend.text = PlayerStats.Gold.ToString();

        buyAndActivateText.transform.parent.gameObject.SetActive(false);

        if (PlayerStats.FirePurchased)
        {
            firePrice.transform.parent.gameObject.SetActive(false);
            firePurchasedText.gameObject.SetActive(true);
            firePurchasedText.text = "Equipped";
        }

        if (PlayerStats.IcePurchased)
        {
            icePrice.transform.parent.gameObject.SetActive(false);
            icePurchasedText.gameObject.SetActive(true);
        }

        if (PlayerStats.LightningPurchased)
        {
            lightningPrice.transform.parent.gameObject.SetActive(false);
            lightningPurchasedText.gameObject.SetActive(true);
        }
    }

    public void FireSelected()
    {
        spellSelected = 0;

        buyAndActivateText.transform.parent.gameObject.SetActive(true);
        buyAndActivateText.transform.parent.gameObject.GetComponent<Button>().interactable = true;

        if (PlayerStats.FirePurchased)
        {
            buyAndActivateText.text = "ACTIVATE";
        }
        else
            buyAndActivateText.text = "PURCHASE";
    }

    public void IceSelected()
    {
        spellSelected = 1;

        buyAndActivateText.transform.parent.gameObject.SetActive(true);
        buyAndActivateText.transform.parent.gameObject.GetComponent<Button>().interactable = true;

        if (PlayerStats.IcePurchased)
        {
            buyAndActivateText.text = "ACTIVATE";
        }
        else if (PlayerStats.IcePurchased == false && PlayerStats.Gold >= iceCost)
        {
            buyAndActivateText.text = "PURCHASE";
        }
        else if (PlayerStats.IcePurchased == false && PlayerStats.Gold < iceCost)
        {
            buyAndActivateText.text = "INSUFFICIENT FUNDS";
            buyAndActivateText.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void LightningSelected()
    {
        spellSelected = 2;

        buyAndActivateText.transform.parent.gameObject.SetActive(true);
        buyAndActivateText.transform.parent.gameObject.GetComponent<Button>().interactable = true;

        if (PlayerStats.LightningPurchased)
        {
            buyAndActivateText.text = "ACTIVATE";
        }
        else if (PlayerStats.LightningPurchased == false && PlayerStats.Gold >= lightningCost)
        {
            buyAndActivateText.text = "PURCHASE";
        }
        else if (PlayerStats.LightningPurchased == false && PlayerStats.Gold < lightningCost)
        {
            buyAndActivateText.text = "INSUFFICIENT FUNDS";
            buyAndActivateText.transform.parent.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public void PurchaseAndActivate()
    {
        if (spellSelected == 0) // Fire
        {
            if (PlayerStats.FirePurchased) // Activate
            {
                PlayerStats.SpellActive = 0;
                firePurchasedText.text = "Equipped";

                if (PlayerStats.IcePurchased)
                {
                    icePurchasedText.text = "Purchased";
                }

                if (PlayerStats.LightningPurchased)
                {
                    lightningPurchasedText.text = "Purchased";
                }
            }           
        }
        else if (spellSelected == 1) // Ice
        {
            if (PlayerStats.IcePurchased) // Activate
            {
                PlayerStats.SpellActive = 1;
                icePurchasedText.text = "Equipped";

                if (PlayerStats.FirePurchased)
                {
                    firePurchasedText.text = "Purchased";
                }

                if (PlayerStats.LightningPurchased)
                {
                    lightningPurchasedText.text = "Purchased";
                }
            }
            else if (PlayerStats.IcePurchased == false && PlayerStats.Gold >= iceCost) // Purchase
            {
                PlayerStats.IcePurchased = true;
                PlayerStats.Gold -= iceCost;
                goldToSpend.text = PlayerStats.Gold.ToString();
                icePrice.transform.parent.gameObject.SetActive(false);
                icePurchasedText.gameObject.SetActive(true);

                // Auto Equip
                PlayerStats.SpellActive = 1;
                icePurchasedText.text = "Equipped";

                if (PlayerStats.FirePurchased)
                {
                    firePurchasedText.text = "Purchased";
                }

                if (PlayerStats.LightningPurchased)
                {
                    lightningPurchasedText.text = "Purchased";
                }
            }
        }
        else if (spellSelected == 2) // Lightning
        {
            if (PlayerStats.LightningPurchased) // Activate
            {
                PlayerStats.SpellActive = 2;
                lightningPurchasedText.text = "Equipped";

                if (PlayerStats.IcePurchased)
                {
                    icePurchasedText.text = "Purchased";
                }

                if (PlayerStats.FirePurchased)
                {
                    firePurchasedText.text = "Purchased";
                }
            }
            else if (PlayerStats.LightningPurchased == false && PlayerStats.Gold >= lightningCost) // Purchase
            {
                PlayerStats.LightningPurchased = true;
                PlayerStats.Gold -= lightningCost;
                goldToSpend.text = PlayerStats.Gold.ToString();
                lightningPrice.transform.parent.gameObject.SetActive(false);
                lightningPurchasedText.gameObject.SetActive(true);

                // Auto Equip
                PlayerStats.SpellActive = 2;
                lightningPurchasedText.text = "Equipped";

                if (PlayerStats.IcePurchased)
                {
                    icePurchasedText.text = "Purchased";
                }

                if (PlayerStats.FirePurchased)
                {
                    firePurchasedText.text = "Purchased";
                }
            }
        }

        StartCoroutine(DeactivatePurchaseButton());
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private IEnumerator DeactivatePurchaseButton()
    {
        Debug.Log("Deactivating");
        yield return new WaitForSeconds(0.5f);
        buyAndActivateText.transform.parent.gameObject.SetActive(false);
    }
}
