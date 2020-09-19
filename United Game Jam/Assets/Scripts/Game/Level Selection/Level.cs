using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private int level;
    private Button_UI button;
    private void Awake()
    {
        transform.Find("Text").GetComponent<TextMeshProUGUI>().text = level.ToString();
        button = GetComponent<Button_UI>();
        button.ClickFunc = () =>
        {
            if(level + 1 < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(1);
                LevelLoader.i.LoadScene(level + 1);
            }
            else
            {
                Debug.LogError("Level : " + level + " does not exist");
            }
            
        };
    }
}
