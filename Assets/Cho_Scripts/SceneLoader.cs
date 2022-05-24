using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void StoreSelectScene()
    {
        SceneManager.LoadScene(1);
    }
    public void GameScene()
    {
        SceneManager.LoadScene(2);
    }
    public void ShoppingScene()
    {
        SceneManager.LoadScene(3);
    }
    public void FinalScene()
    {
        SceneManager.LoadScene(4);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
