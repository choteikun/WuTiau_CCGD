using UnityEngine;
using System.Collections;
using System;

public class ShopSystem
{
    private const string COIN_KEY = "Coin";
    public static Action<int> OnCoinChange = delegate {};
    public MyStoreObj myStoreObj;

    public static int Get()
    {
        Debug.Log(PlayerPrefs.GetInt(COIN_KEY, 0));
        return PlayerPrefs.GetInt(COIN_KEY, 0);
    }

    public static bool Add(int coin)
    {
        if (coin < 0) {
            return false;
        }
        CoinChange(Get() + coin);
        return true;
    }

    public static bool Buy(int coin)
    {
        if (coin < 0) {
            return false;
        }

        if (Get() - coin < 0) {
            return false;
        }

        CoinChange(Get() - coin);
        //CoinChange(PlayerPrefs.GetInt(COIN_KEY, 0) - coin);
        return true;
    }

    public static void CoinReset()//錢歸零
    {
        CoinChange(0);
    }
    public static void CoinChange(int coin)
    {
        PlayerPrefs.SetInt(COIN_KEY, coin);
        PlayerPrefs.Save();
        OnCoinChange(PlayerPrefs.GetInt(COIN_KEY, 0));
    }

    //public static void CoinChange()
    //{
    //    OnCoinChange(PlayerPrefs.GetInt(COIN_KEY, 0));
    //}
}
