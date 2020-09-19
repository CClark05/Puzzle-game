using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;
using System;

public class Game_UI : MonoBehaviour
{
    public static Game_UI i;
    [SerializeField] private Button_UI playButton;
    [SerializeField] private Button_UI restartButton;
    [SerializeField] private Button_UI discardButton;
    public static event Action onPlayButtonClicked;
    public static event Action onRestartButtonClicked;
    public static event Action onDiscardButtonClicked;
    private void Awake()
    {
        i = this;
        playButton.ClickFunc = () =>
        {
            onPlayButtonClicked?.Invoke();
        };
        restartButton.ClickFunc = () =>
        {
            onRestartButtonClicked?.Invoke();
            GameManager.i.RestartSimulation();
        };
        discardButton.ClickFunc = () =>
        { 
            onDiscardButtonClicked?.Invoke();
        };


    }

    public void ShowButton(string button)
    {
        if(transform.Find(button) != null)
        {
            transform.Find(button).gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError(button + " does not exist");
        }
        
    }
    public void HideButton(string button)
    {
        if (transform.Find(button) != null)
        {
            transform.Find(button).gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError(button + " does not exist");
        }

    }

}
