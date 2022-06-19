using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntrodutiocPlace : MonoBehaviour
{
    public GameObject setPlace;
    public WholesaleMarketObj wholesaleMarketObj;
    public MyStoreObj myStoreObj;

    [Header("�����ۭq�q���Ҧ���l�ӫ~����")]
    public int customItemPrice;
    [Header("�����ۭq�q���Ҧ���l���Ħ���")]
    public int customCostPerHire;
    
    [Header("�����ۭq�q���쪫�ƻ���Y��---�s���Y")][Space(10)]
    public float hsinKangChien_ItemPriceRefCoefficient;
    [Header("�����ۭq�q�����Ħ����Y��---�s���Y")]
    public float hsinKangChien_CostPerHireRefCoefficient;

    [Header("�����ۭq�q���쪫�ƻ���Y��---���Y��")][Space(10)]
    public float foTou_ItemPriceRefCoefficient;
    [Header("�����ۭq�q�����Ħ����Y��---���Y��")]
    public float foTou_CostPerHireRefCoefficient;

    [Header("�����ۭq�q���쪫�ƻ���Y��---�n�մ�")][Space(10)]
    public float nanShih_ItemPriceRefCoefficient;
    [Header("�����ۭq�q�����Ħ����Y��---�n�մ�")]
    public float nanShih_CostPerHireRefCoefficient;

    [Header("�����ۭq�q���쪫�ƻ���Y��---�n�e��")][Space(10)]
    public float nanHe_ItemPriceRefCoefficient;
    [Header("�����ۭq�q�����Ħ����Y��---�n�e��")]
    public float nanHe_CostPerHireRefCoefficient;

    [Header("�����ۭq�q���쪫�ƻ���Y��---�w����")][Space(10)]
    public float anHai_ItemPriceRefCoefficient;
    [Header("�����ۭq�q�����Ħ����Y��---�w����")]
    public float anHai_CostPerHireRefCoefficient;

    //��D²��
    Image _hsinKangChien;
    Image _foTou;
    Image _nanShih;
    Image _nanHe;
    Image _anHai;

    //���D�Ϥ�
    Image T1;
    Image T2;
    Image T3;
    Image T4;
    Image T5;

    //�ݩʹϤ�
    Image A1;
    Image A2;
    Image A3;
    Image A4;
    Image A5;

    bool switchButton;
    enum Port
    {
        HsinKangChien,
        FoTou,
        NanShih,
        NanHe,
        AnHai
    }
    Port port_Select;

    Color alpha0 = new Color(1.0f, 1.0f, 1.0f, 0);//�z��
    Color alpha1 = new Color(1.0f, 1.0f, 1.0f, 1.0f);//���z��

    private void Start()
    {
        switchButton = false;
        _hsinKangChien = setPlace.transform.Find("HsinKangChien(Image)").gameObject.GetComponent<Image>();
        _foTou = setPlace.transform.Find("FoTou(Image)").gameObject.GetComponent<Image>();
        _nanShih = setPlace.transform.Find("NanShih(Image)").gameObject.GetComponent<Image>();
        _nanHe = setPlace.transform.Find("NanHe(Image)").gameObject.GetComponent<Image>();
        _anHai = setPlace.transform.Find("AnHai(Image)").gameObject.GetComponent<Image>();

        T1 = setPlace.transform.Find("T1(Image)").gameObject.GetComponent<Image>();
        T2 = setPlace.transform.Find("T2(Image)").gameObject.GetComponent<Image>();
        T3 = setPlace.transform.Find("T3(Image)").gameObject.GetComponent<Image>();
        T4 = setPlace.transform.Find("T4(Image)").gameObject.GetComponent<Image>();
        T5 = setPlace.transform.Find("T5(Image)").gameObject.GetComponent<Image>();

        A1 = setPlace.transform.Find("A1(Image)").gameObject.GetComponent<Image>();
        A2 = setPlace.transform.Find("A2(Image)").gameObject.GetComponent<Image>();
        A3 = setPlace.transform.Find("A3(Image)").gameObject.GetComponent<Image>();
        A4 = setPlace.transform.Find("A4(Image)").gameObject.GetComponent<Image>();
        A5 = setPlace.transform.Find("A5(Image)").gameObject.GetComponent<Image>();
    }

    public void HsinKangChien()//�ϥΫ��s�w�q�X�}�l�C���᪺�쪫�ƻ���&���Ħ���
    {
        port_Select = Port.HsinKangChien;
        wholesaleMarketObj.itemPrice = (int)Mathf.Round(customItemPrice * hsinKangChien_ItemPriceRefCoefficient * myStoreObj.kindOfStoret_refCoefficient);
        wholesaleMarketObj.costPerHire = (int)Mathf.Round(customCostPerHire * hsinKangChien_CostPerHireRefCoefficient * myStoreObj.kindOfStoret_refCoefficient);
        Alpha0();
        _hsinKangChien.color = alpha1;
        T1.color = alpha1;       
    }
    public void FoTou()
    {
        port_Select = Port.FoTou;
        wholesaleMarketObj.itemPrice = (int)Mathf.Round(customItemPrice * foTou_ItemPriceRefCoefficient * myStoreObj.kindOfStoret_refCoefficient);
        wholesaleMarketObj.costPerHire = (int)Mathf.Round(customCostPerHire * foTou_CostPerHireRefCoefficient * myStoreObj.kindOfStoret_refCoefficient);
        Alpha0();
        _foTou.color = alpha1;
        T2.color = alpha1;
    }
    public void NanShih()
    {
        port_Select = Port.NanShih;
        wholesaleMarketObj.itemPrice = (int)Mathf.Round(customItemPrice * nanShih_ItemPriceRefCoefficient * myStoreObj.kindOfStoret_refCoefficient);
        wholesaleMarketObj.costPerHire = (int)Mathf.Round(customCostPerHire * nanShih_CostPerHireRefCoefficient * myStoreObj.kindOfStoret_refCoefficient);
        Alpha0();
        _nanShih.color = alpha1;
        T3.color = alpha1;
    }
    public void NanHe()
    {
        port_Select = Port.NanHe;
        wholesaleMarketObj.itemPrice = (int)Mathf.Round(customItemPrice * nanHe_ItemPriceRefCoefficient * myStoreObj.kindOfStoret_refCoefficient);
        wholesaleMarketObj.costPerHire = (int)Mathf.Round(customCostPerHire * nanHe_CostPerHireRefCoefficient * myStoreObj.kindOfStoret_refCoefficient);
        Alpha0();
        _nanHe.color = alpha1;
        T4.color = alpha1;

    }
    public void AnHai()
    {
        port_Select = Port.AnHai;
        wholesaleMarketObj.itemPrice = (int)Mathf.Round(customItemPrice * anHai_ItemPriceRefCoefficient * myStoreObj.kindOfStoret_refCoefficient);
        wholesaleMarketObj.costPerHire = (int)Mathf.Round(customCostPerHire * anHai_CostPerHireRefCoefficient * myStoreObj.kindOfStoret_refCoefficient);
        Alpha0();
        _anHai.color = alpha1;
        T5.color = alpha1;
    }
    public void Alpha0()
    {
        switchButton = false;

        _hsinKangChien.color = alpha0;
        _foTou.color = alpha0;
        _nanShih.color = alpha0;
        _nanHe.color = alpha0;
        _anHai.color = alpha0;

        T1.color = alpha0;
        T2.color = alpha0;
        T3.color = alpha0;
        T4.color = alpha0;
        T5.color = alpha0;

        A1.color = alpha0;
        A2.color = alpha0;
        A3.color = alpha0;
        A4.color = alpha0;
        A5.color = alpha0;
    }
    public void SwitchButton()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "papperflip_se");
        switchButton = !switchButton;
        if (switchButton)
        {
            switch (port_Select)
            {
                case Port.HsinKangChien:
                    _hsinKangChien.color = alpha0;
                    A1.color = alpha1;
                    break;
                case Port.FoTou:
                    _foTou.color = alpha0;
                    A2.color = alpha1;
                    break;
                case Port.NanShih:
                    _nanShih.color = alpha0;
                    A3.color = alpha1;
                    break;
                case Port.NanHe:
                    _nanHe.color = alpha0;
                    A4.color = alpha1;
                    break;
                case Port.AnHai:
                    _anHai.color = alpha0;
                    A5.color = alpha1;
                    break;
            }
        }
        else
        {
            switch (port_Select)
            {
                case Port.HsinKangChien:
                    _hsinKangChien.color = alpha1;
                    A1.color = alpha0;
                    break;
                case Port.FoTou:
                    _foTou.color = alpha1;
                    A2.color = alpha0;
                    break;
                case Port.NanShih:
                    _nanShih.color = alpha1;
                    A3.color = alpha0;
                    break;
                case Port.NanHe:
                    _nanHe.color = alpha1;
                    A4.color = alpha0;
                    break;
                case Port.AnHai:
                    _anHai.color = alpha1;
                    A5.color = alpha0;
                    break;
            }
        }
    }
}
