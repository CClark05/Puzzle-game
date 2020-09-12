using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;
using System;

public class Game_UI : MonoBehaviour
{
    [SerializeField] private Button_UI playButton;
    [SerializeField] private Button_UI restartButton;
    public static event Action onPlayButtonClicked;
    public static event Action onRestartButtonClicked;
    private void Awake()
    {
        playButton.ClickFunc = () =>
        {
            onPlayButtonClicked?.Invoke();
        };
        restartButton.ClickFunc = () =>
        {
            onRestartButtonClicked?.Invoke();
        };

    }
}
