using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public static LevelLoader i;
    private void Awake()
    {
        i = this;
    }
    
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadSceneAsync(buildIndex, LoadSceneMode.Additive);
    }

    public void RemoveScene(int buildIndex)
    {
        SceneManager.UnloadSceneAsync(buildIndex);
    }
    public void ChangeScene(int buildIndex, int removeIndex)
    {
        RemoveScene(removeIndex);
        LoadScene(buildIndex);

    }
}
