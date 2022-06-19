using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WholesaleMarket", menuName = "WholesaleMarketObj")]
public class WholesaleMarketObj : ScriptableObject
{
    [Header("選擇完商店&地區後的原物料價格")]
    public int itemPrice;
    [Header("選擇完商店&地區後的僱傭成本")]
    public int costPerHire;
}
