using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalSceneCanvas : MonoBehaviour
{
    public GameObject[] uiRoot;
    public MyStoreObj myStoreObj;

    
    [Header("總額數字跳動總次數")]
    public int myCoinTextRate;
    [Header("獲得代幣跳動總次數")]
    public int myTokenCoinTextRate;
    [Header("總額數字幾秒跳動一次")]
    public float myCoinJumpTime;
    [Header("獲得代幣數字幾秒跳動一次")]
    public float myTokenCoinJumpTime;

    TMP_Text myCoinText;
    TMP_Text tokenCoinText;
    TMP_Text myTargetCoinText;

    Image surStoreImage;
    Image medStoreImage;
    Image cloStoreImage;

    Image successImage;
    Image failedImage;

    int myCoinShowNum;
    int myTokenCoinShowNum;
    int myTokenCoinCalculate;
    int myTokenCoin;

    Color alpha0 = new Color(1.0f, 1.0f, 1.0f, 0);//透明
    Color alpha1 = new Color(1.0f, 1.0f, 1.0f, 1.0f);//不透明

    private void Start()
    {
        myTokenCoinCalculate = (int)Mathf.Round(myStoreObj.myCoin * 0.01f);
        if (myTokenCoinCalculate > 0)
        {
            myTokenCoin = myTokenCoinCalculate;
        }
        else
        {
            myTokenCoin = 0;
        }
        myStoreObj.myTokenCoin += myTokenCoin;


        surStoreImage = uiRoot[0].transform.Find("SurStore(Image)").GetComponent<Image>();
        medStoreImage = uiRoot[0].transform.Find("MedStore(Image)").GetComponent<Image>();
        cloStoreImage = uiRoot[0].transform.Find("CloStore(Image)").GetComponent<Image>();

        successImage = uiRoot[2].transform.Find("Success(Image)").GetComponent<Image>();
        failedImage = uiRoot[2].transform.Find("Failed(Image)").GetComponent<Image>();

        switch (myStoreObj.kindOfStore)
        {
            case "糖郊":
                surStoreImage.color = alpha1;
                medStoreImage.color = alpha0;
                cloStoreImage.color = alpha0;
                break;
            case "南郊":
                medStoreImage.color = alpha1;
                surStoreImage.color = alpha0;
                cloStoreImage.color = alpha0;
                break;
            case "北郊":
                cloStoreImage.color = alpha1;
                surStoreImage.color = alpha0;
                medStoreImage.color = alpha0;
                break;
        }

        if (myStoreObj.myCoin < myStoreObj.myTargetCoin)//任務達成與否的判斷
        {
            myStoreObj.missionState = false;
        }
        else
        {
            myStoreObj.missionState = true;
        }

        if (myStoreObj.missionState)//任務達成
        {
            successImage.color = alpha1;
            failedImage.color = alpha0;
        }
        else
        {
            successImage.color = alpha0;
            failedImage.color = alpha1;
        }
        myCoinText = uiRoot[1].transform.Find("MyCoinText(TMP)").GetComponent<TMP_Text>();
        tokenCoinText = uiRoot[2].transform.Find("TokenCoinText(TMP)").GetComponent<TMP_Text>();
        myTargetCoinText = uiRoot[3].transform.Find("TargetText(TMP)").GetComponent<TMP_Text>();

        myTargetCoinText.text = myStoreObj.myTargetCoin.ToString();
        Invoke("DelayTimeShowMyCoinNum", 3f);
        Invoke("DelayTimeShowMyTokenCoinNum", 10f);
    }

    public IEnumerator MyCoinJump()
    {
        int delta = myStoreObj.myCoin / myCoinTextRate;
        for (int i = 0; i < myCoinTextRate; i++)
        {
            myCoinShowNum += delta;
            myCoinText.text = myCoinShowNum.ToString();
            yield return new WaitForSeconds(myCoinJumpTime);
            //yield return 1;
        }
        myCoinShowNum = myStoreObj.myCoin;
        myCoinText.text = myCoinShowNum.ToString();
        StopCoroutine(MyCoinJump());
    }
    public IEnumerator MyTokenCoinJump()
    {
        int delta = myTokenCoin / myTokenCoinTextRate;
        for (int i = 0; i < myTokenCoinTextRate; i++)
        {
            myTokenCoinShowNum += delta;
            tokenCoinText.text = myTokenCoinShowNum.ToString();
            yield return new WaitForSeconds(myTokenCoinJumpTime);
            //yield return 1;
        }

        myTokenCoinShowNum = myTokenCoin;
        tokenCoinText.text = myTokenCoinShowNum.ToString();
        StopCoroutine(MyTokenCoinJump());
    }

    public void DelayTimeShowMyCoinNum()
    {
        StartCoroutine(MyCoinJump());
    }
    public void DelayTimeShowMyTokenCoinNum()
    {
        StartCoroutine(MyTokenCoinJump());
    }
}
