using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private Sprite altSprite;
    private Button_UI button;
    private bool completed;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        transform.Find("Text").GetComponent<TextMeshProUGUI>().text = level.ToString();
        button = GetComponent<Button_UI>();
        button.ClickFunc = () =>
        {
            if(level +  1 < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(SceneHandler.GetSceneIndex(SceneHandler.Scenes.Game));
                LevelLoader.i.LoadScene(level + 2);
                GameManager.currentLevel = level;
            }
            else
            {
                Debug.LogError("Level : " + level + " does not exist");
            }
           
        };

        if (!completed)
        {
            for (var i = 0; i < GameManager.i.completedLevels.Count; i++)
            {
                if (GameManager.i.completedLevels[i] == level)
                {
                    image.sprite = altSprite;
                    completed = true;
                    return;
                }
            }
        }
        
    }


    
}
