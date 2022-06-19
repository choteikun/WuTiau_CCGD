using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinText : MonoBehaviour
{
    private Text coinText;

    void Awake ()
    {
        ShopSystem.OnCoinChange += OnCoinChange;
        coinText = transform.GetComponent<Text>();
        ShopSystem.CoinChange(0);
    }

    private void OnCoinChange(int coin)
    {
        coinText.text = "coin:" + coin.ToString();
    }
}
