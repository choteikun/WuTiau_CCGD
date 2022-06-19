using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MyStore", menuName ="MyStoreObj")]
public class MyStoreObj : ScriptableObject
{
    [Header("玩家錢包")]
    public int myCoin;
    [Header("玩家錢包初始值")]
    public int initialMyCoin;

    [Header("一次賣出賺的錢")]
    public int earnCoin;

    [Header("商店種類")]
    public string kindOfStore;
    [Header("商店等級")]
    public int myStoreLv;
    [Header("商店下一個等級")]
    public int myStoreNextLv;
    [Header("升級費用")]
    public int levelUpCost;

    [Header("目前原料量")]
    public int curInputItems;
    [Header("倉庫可存的最大原料量")]
    public int maxInputItems;
    [Header("目前商品量")]
    public int curOutputItems;
    [Header("倉庫可存的最大商品量")]
    public int maxOutputItems;

    [Header("目前員工人數")]
    public int curStaffs;
    [Header("員工總數最大值")]
    public int maxStaffs;
    [Header("備貨人員")]
    public int stockingStaff;
    [Header("出貨人員")]
    public int shippingStaff;

    [Header("單次備貨量")]
    public int stockingOnceAmount;
    [Header("單次出貨量")]
    public int shippingOnceAmount;
    [Header("備貨所需時間")]
    public int stockingNeedTime;//備貨所需時間(企劃訂定)
    [Header("出貨所需時間")]
    public int shippingNeedTime;//出貨所需時間(企劃訂定)

    [Header("批發市場所需要的參考係數")]
    public float kindOfStoret_refCoefficient;//供給量固定但價格不一樣所需之係數

    [Header("玩家目標金額")]
    public int myTargetCoin;
    [Header("任務達成與否")]
    public bool missionState = true;
}
