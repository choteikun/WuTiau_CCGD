using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSelect : MonoBehaviour
{
    public GameObject storeSelect;
    public MyStoreObj myStoreObj;

    //店鋪簡介
    Image _surStore;
    Image _medStore;
    Image _cloStore;

    //標題圖片
    Image T1;
    Image T2;
    Image T3;

    //屬性圖片
    Image A1;
    Image A2;
    Image A3;

    bool switchButton;
    enum Store
    {
        SurStore,
        MedStore,
        CloStore
    }
    Store store_Select;

    Color alpha0 = new Color(1.0f, 1.0f, 1.0f, 0);//透明
    Color alpha1 = new Color(1.0f, 1.0f, 1.0f, 1.0f);//不透明

    void Awake()
    {
        switchButton = false;

        _surStore = storeSelect.transform.Find("surStore(Image)").gameObject.GetComponent<Image>();
        _medStore = storeSelect.transform.Find("medStore(Image)").gameObject.GetComponent<Image>();
        _cloStore = storeSelect.transform.Find("cloStore(Image)").gameObject.GetComponent<Image>();

        T1 = storeSelect.transform.Find("T1(Image)").gameObject.GetComponent<Image>();
        T2 = storeSelect.transform.Find("T2(Image)").gameObject.GetComponent<Image>();
        T3 = storeSelect.transform.Find("T3(Image)").gameObject.GetComponent<Image>();

        A1 = storeSelect.transform.Find("A1(Image)").gameObject.GetComponent<Image>();
        A2 = storeSelect.transform.Find("A2(Image)").gameObject.GetComponent<Image>();
        A3 = storeSelect.transform.Find("A3(Image)").gameObject.GetComponent<Image>();
    }
    

    public void SurStore()
    {
        myStoreObj.myStoreLv = 1;
        myStoreObj.myStoreNextLv = 2;
        myStoreObj.myCoin = 750;
        myStoreObj.initialMyCoin = 750;
        myStoreObj.stockingStaff = 0;
        myStoreObj.shippingStaff = 0;
        myStoreObj.curStaffs = 1;
        myStoreObj.curInputItems = 0;
        myStoreObj.curOutputItems = 0;
        myStoreObj.maxInputItems = 2000;
        myStoreObj.maxOutputItems = 1200;
        myStoreObj.maxStaffs = 3;
        myStoreObj.levelUpCost = 5000;
        myStoreObj.stockingOnceAmount = 200;
        myStoreObj.shippingOnceAmount = 200;
        myStoreObj.earnCoin = 500;

        store_Select = Store.SurStore;
        Alpha0();
        _surStore.color = alpha1;
        T1.color = alpha1;
    }
    public void MedStore()
    {
        myStoreObj.myStoreLv = 1;
        myStoreObj.myStoreNextLv = 2;
        myStoreObj.myCoin = 3000;
        myStoreObj.initialMyCoin = 3000;
        myStoreObj.stockingStaff = 0;
        myStoreObj.shippingStaff = 0;
        myStoreObj.curStaffs = 1;
        myStoreObj.curInputItems = 0;
        myStoreObj.curOutputItems = 0;
        myStoreObj.maxInputItems = 500;
        myStoreObj.maxOutputItems = 300;
        myStoreObj.maxStaffs = 2;
        myStoreObj.levelUpCost = 5000;
        myStoreObj.stockingOnceAmount = 50;
        myStoreObj.shippingOnceAmount = 50;
        myStoreObj.earnCoin = 500;

        store_Select = Store.MedStore;
        Alpha0();
        _medStore.color = alpha1;
        T2.color = alpha1;
    }
    public void CloStore()
    {
        myStoreObj.myStoreLv = 1;
        myStoreObj.myStoreNextLv = 2;
        myStoreObj.myCoin = 1500;
        myStoreObj.initialMyCoin = 1500;
        myStoreObj.stockingStaff = 0;
        myStoreObj.shippingStaff = 0;
        myStoreObj.curStaffs = 1;
        myStoreObj.curInputItems = 0;
        myStoreObj.curOutputItems = 0;
        myStoreObj.maxInputItems = 1000;
        myStoreObj.maxOutputItems = 600;
        myStoreObj.maxStaffs = 3;
        myStoreObj.levelUpCost = 5000;
        myStoreObj.stockingOnceAmount = 100;
        myStoreObj.shippingOnceAmount = 100;
        myStoreObj.earnCoin = 500;

        store_Select = Store.CloStore;
        Alpha0();
        _cloStore.color = alpha1;
        T3.color = alpha1;
    }
    public void Alpha0()
    {
        switchButton = false;

        _surStore.color = alpha0;
        _medStore.color = alpha0;
        _cloStore.color = alpha0;

        T1.color = alpha0;
        T2.color = alpha0;
        T3.color = alpha0;

        A1.color = alpha0;
        A2.color = alpha0;
        A3.color = alpha0;
    }
    public void SwitchButton()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "papperflip_se");
        switchButton = !switchButton;
        if (switchButton)
        {
            switch (store_Select)
            {
                case Store.SurStore:
                    _surStore.color = alpha0;
                    A1.color = alpha1;
                    break;
                case Store.MedStore:
                    _medStore.color = alpha0;
                    A2.color = alpha1;
                    break;
                case Store.CloStore:
                    _cloStore.color = alpha0;
                    A3.color = alpha1;
                    break;
            }
        }
        else
        {
            switch (store_Select)
            {
                case Store.SurStore:
                    _surStore.color = alpha1;
                    A1.color = alpha0;
                    break;
                case Store.MedStore:
                    _medStore.color = alpha1;
                    A2.color = alpha0;
                    break;
                case Store.CloStore:
                    _cloStore.color = alpha1;
                    A3.color = alpha0;
                    break;
            }
        }
    }
}
