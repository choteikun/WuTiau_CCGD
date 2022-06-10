using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinShop : MonoBehaviour
{
    public GameObject skinShopObj;

    void Start()
    {

    }


    void Update()
    {
        
    }
    public void SkinShopBuy()
    {
        GameObject blueSkinQA = skinShopObj.transform.Find("Buy&Check(Image)").gameObject;
        blueSkinQA.SetActive(true);
    }
    public void SkinShopQA_Yes()
    {
        GameObject blueSkinSelected = skinShopObj.transform.Find("BlueSkinSelected(Image)").gameObject;
        blueSkinSelected.SetActive(true);
    }
    public void SkinShopQA_No()
    {
        GameObject blueSkinQA = skinShopObj.transform.Find("Buy&Check(Image)").gameObject;
        blueSkinQA.SetActive(false);
    }
}
