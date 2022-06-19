using UnityEngine;
using System.Collections;

public class CoinButton : MonoBehaviour
{
    public MyStoreObj myStoreObj;

    public void AddCoin100Button()
    {
        myStoreObj.myCoin += 100;
        ShopSystem.Add(100);
    }

    public void CoinReset()//錢歸零
    {
        ShopSystem.CoinReset();
        //ShopSystem.Sub(ShopSystem.Get());
    }

    public void Buy100Button()
    {
        myStoreObj.myCoin -= 100;
        ShopSystem.Buy(100);
    }

    public void Buy500Buttn()
    {
        myStoreObj.myCoin -= 500;
        ShopSystem.Buy(500);
    }

    public void Buy1000Button()
    {
        myStoreObj.myCoin -= 1000;
        ShopSystem.Buy(1000);
    }
}
