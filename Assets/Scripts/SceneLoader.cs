using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartScene()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "choose_se");
        StartCoroutine(DelayedStartScene());

    }
    public void StoreSelectScene()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "choose_se");
        StartCoroutine(DelayedStoreSelectScene());
    }
    public void SettingPositionScene()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "choose_se");
        StartCoroutine(DelayedSettingPositionScene());
    }
    public void GameScene()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "choose_se");
        StartCoroutine(DelayedGameScene());
    }
    public void ShoppingScene()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "choose_se");
        StartCoroutine(DelayedShoppingScene());
    }
    public void FinalScene()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "choose_se");
        StartCoroutine(DelayedFinalScene());
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    IEnumerator DelayedStartScene()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(0);
    }
    IEnumerator DelayedStoreSelectScene()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(1);
    }
    IEnumerator DelayedSettingPositionScene()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(2);
    }
    IEnumerator DelayedShoppingScene()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(3);
    }
    IEnumerator DelayedGameScene()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(4);
    }
    IEnumerator DelayedFinalScene()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(5);
    }
}
