using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemButton : MonoBehaviour
{
    public int price = 1000;
    private Button itemButton;

    void Awake ()
    {
        ShopSystem.OnCoinChange += OnCoinChange;
        itemButton = transform.GetComponent<Button>();
        ShopSystem.CoinChange();
    }

    private void OnCoinChange(int coin)
    {
        itemButton.interactable = coin >= price ? true : false;
    }
}
