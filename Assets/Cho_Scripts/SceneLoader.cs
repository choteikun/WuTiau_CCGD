using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartScene()
    {      
        StartCoroutine(DelayedStartScene());
    }
    public void StoreSelectScene()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "choose_se");
        StartCoroutine(DelayedStoreSelectScene());
    }
    public void GameScene()
    {
        SceneManager.LoadScene(2);
    }
    public void ShoppingScene()
    {
        AudioSourceController.PlaySE("Cho_Sounds", "choose_se");
        StartCoroutine(DelayedShoppingScene());
    }
    public void FinalScene()
    {
        SceneManager.LoadScene(4);
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
    IEnumerator DelayedShoppingScene()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(3);
    }
}
