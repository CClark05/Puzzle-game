using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;
public class Level_UI : MonoBehaviour
{
    [SerializeField] private Button_UI rightArrow;
    [SerializeField] private Button_UI leftArrow;
    [SerializeField] private int level;
    private void Awake()
    {
        rightArrow.ClickFunc = () =>
        {
            GameManager.currentLevel = level + 1;
            SceneManager.LoadScene(SceneHandler.GetSceneIndex(SceneHandler.Scenes.Game));
            LevelLoader.i.ChangeScene(level + SceneHandler.sceneNum, level + (SceneHandler.sceneNum - 1));
            
        };
        if (leftArrow != null)
        {
            leftArrow.ClickFunc = () =>
            {
                GameManager.currentLevel = level - 1;
                SceneManager.LoadScene(SceneHandler.GetSceneIndex(SceneHandler.Scenes.Game));
                LevelLoader.i.ChangeScene(level + SceneHandler.sceneNum - 2, level + SceneHandler.sceneNum - 1);
            };
        }
    }
}
