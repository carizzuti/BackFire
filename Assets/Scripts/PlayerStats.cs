using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    private static int silver;

    private static bool firePurchased = true, 
        icePurchased = false, 
        lightningPurchased = false;

    private static int spellActive;
    private static int gold = 13;

    public static int Silver
    {
        get
        {
            return silver;
        }
        set
        {
            silver = value;
        }
    }

    public static int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
        }
    }

    public static bool FirePurchased
    {
        get
        {
            return firePurchased;
        }
        set
        {
            firePurchased = value;
        }
    }

    public static bool IcePurchased
    {
        get
        {
            return icePurchased;
        }
        set
        {
            icePurchased = value;
        }
    }

    public static bool LightningPurchased
    {
        get
        {
            return lightningPurchased;
        }
        set
        {
            lightningPurchased = value;
        }
    }

    public static int SpellActive
    {
        get { return spellActive; }
        set { spellActive = value; }
    }
}
