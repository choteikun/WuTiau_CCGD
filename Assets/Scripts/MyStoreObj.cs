using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MyStore", menuName ="MyStoreObj")]
public class MyStoreObj : ScriptableObject
{
    [Header("���a���]")]
    public int myCoin;
    [Header("���a���]��l��")]
    public int initialMyCoin;

    [Header("�@����X�Ȫ���")]
    public int earnCoin;

    [Header("�ө�����")]
    public string kindOfStore;
    [Header("�ө�����")]
    public int myStoreLv;
    [Header("�ө��U�@�ӵ���")]
    public int myStoreNextLv;
    [Header("�ɯŶO��")]
    public int levelUpCost;

    [Header("�ثe��ƶq")]
    public int curInputItems;
    [Header("�ܮw�i�s���̤j��ƶq")]
    public int maxInputItems;
    [Header("�ثe�ӫ~�q")]
    public int curOutputItems;
    [Header("�ܮw�i�s���̤j�ӫ~�q")]
    public int maxOutputItems;

    [Header("�ثe���u�H��")]
    public int curStaffs;
    [Header("���u�`�Ƴ̤j��")]
    public int maxStaffs;
    [Header("�Ƴf�H��")]
    public int stockingStaff;
    [Header("�X�f�H��")]
    public int shippingStaff;

    [Header("�榸�Ƴf�q")]
    public int stockingOnceAmount;
    [Header("�榸�X�f�q")]
    public int shippingOnceAmount;
    [Header("�Ƴf�һݮɶ�")]
    public int stockingNeedTime;//�Ƴf�һݮɶ�(�����q�w)
    [Header("�X�f�һݮɶ�")]
    public int shippingNeedTime;//�X�f�һݮɶ�(�����q�w)

    [Header("��o�����һݭn���ѦҫY��")]
    public float kindOfStoret_refCoefficient;//�ѵ��q�T�w�����椣�@�˩һݤ��Y��

    [Header("���a�ؼЪ��B")]
    public int myTargetCoin;
    [Header("���ȹF���P�_")]
    public bool missionState = true;
}
