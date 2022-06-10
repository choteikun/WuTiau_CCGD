using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemButton : MonoBehaviour
{
    [Header("價格浮動大小修正曲線")]
    public AnimationCurve priceFluctuationCurve;
    public int price = 1000;
    private Button itemButton;

    void Awake ()
    {
        ShopSystem.OnCoinChange += OnCoinChange;
        itemButton = transform.GetComponent<Button>();
        ShopSystem.CoinChange();
        //updatePriceEveryDay();
    }

    private void OnCoinChange(int coin)
    {
        itemButton.interactable = coin >= price ? true : false;
    }
    public void updatePriceEveryDay()//每天價格刷新
    {
        SetPriceFluctuation(Random.Range(1.0f, 5.0f));//一個軸向的隨機選數
    }
    public void SetPriceFluctuation(float fluctuation)//SetPriceFluctuation用來設一軸向的值再利用animation.curve功能可以得出另一軸向的值
    {
        price = (int)Mathf.Round(price * priceFluctuationCurve.Evaluate(fluctuation));//價格(另一軸向)在浮動域裡變化
    }
}
