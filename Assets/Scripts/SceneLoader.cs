using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartSceneLoad()
    {
        SceneManager.LoadScene(0);
    }
    public void SceneLoad_1()
    {
        SceneManager.LoadScene(1);
    }
    public void SceneLoad_2()
    {
        SceneManager.LoadScene(2);
    }
    public void SceneLoad_3()
    {
        SceneManager.LoadScene(3);
    }
    public void FinalSceneLoad()
    {
        SceneManager.LoadScene(4);
    }
}
