using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WholesaleMarket", menuName = "WholesaleMarketObj")]
public class WholesaleMarketObj : ScriptableObject
{
    [Header("��ܧ��ө�&�a�ϫ᪺�쪫�ƻ���")]
    public int itemPrice;
    [Header("��ܧ��ө�&�a�ϫ᪺���Ħ���")]
    public int costPerHire;
}
