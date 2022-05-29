using UnityEngine;
using System.Collections;

public class CoinButton : MonoBehaviour
{
    public void AddCoin100Button()
    {
        ShopSystem.Add(100);
    }

    public void CoinReset()//錢歸零
    {
        ShopSystem.CoinReset();
        //ShopSystem.Sub(ShopSystem.Get());
    }

    public void Buy100Button()
    {
        ShopSystem.Buy(100);
    }

    public void Buy500Buttn()
    {
        ShopSystem.Buy(500);
    }

    public void Buy1000Button()
    {
        ShopSystem.Buy(1000);
    }
}
