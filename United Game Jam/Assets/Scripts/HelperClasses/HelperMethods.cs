using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using CodeMonkey.Utils;
using UnityEngine.UI;

public static class HelperMethods 
{
    public static void Pause()
    {
        Time.timeScale = 0;
    }
    public static void Resume()
    {
        Time.timeScale = 1;
    }
    public static void ButtonBehaviour(Button_UI button, float sizeIncrease, Action onClick, bool useArrows)
    {
        float originalTextSize;
        Color originalColor;
        TextMeshProUGUI buttonTxt = button.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        originalColor = buttonTxt.color;
        originalTextSize = buttonTxt.fontSize;
            
        button.MouseOverOnceFunc = () =>
        {
            AudioManager.instance.Play("Button Hover");
            buttonTxt.fontSize = originalTextSize + sizeIncrease;
            buttonTxt.color = Color.white;  
            if (useArrows)
            {
                button.transform.Find("Left Arrow").gameObject.SetActive(true);
                button.transform.Find("Right Arrow").gameObject.SetActive(true);
            }
        };
        button.MouseOutOnceFunc = () =>
        {
            buttonTxt.fontSize = originalTextSize;
            buttonTxt.color = originalColor;
            if (useArrows)
            {
                button.transform.Find("Left Arrow").gameObject.SetActive(false);
                button.transform.Find("Right Arrow").gameObject.SetActive(false);
            }
        };
        button.ClickFunc = () =>
        {
            AudioManager.instance.Play("Button Click");

            onClick?.Invoke();
        };
    }
    public static void SwitchScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public static void FadeIn(float duration, GameObject panel, Action onFinished)
    {

        if (panel != null)
        {
            panel.SetActive(true);
            TweenLibrary.LeanFadeUI_Image(panel.gameObject, panel.GetComponent<Image>(), 1, 0, duration, () =>
            {
                panel.gameObject.SetActive(false);
                onFinished?.Invoke();
            });
        }
        
    }
    public static void FadeOut(float duration, GameObject panel, Action onFinished)
    {

        if (panel != null)
        {
            panel.SetActive(true);
            TweenLibrary.LeanFadeUI_Image(panel.gameObject, panel.GetComponent<Image>(), 0, 1, duration, onFinished);
        }

    }

    public static TextMeshPro CreateText(Transform parent, string text, Vector2 position, float size, TMP_FontAsset font, Color color)
    {
        GameObject textObject = new GameObject("Created Text", typeof(TextMeshPro));
        textObject.transform.SetParent(parent);
        textObject.transform.position = position;
        textObject.GetComponent<TextMeshPro>().text = text;
        textObject.GetComponent<TextMeshPro>().fontSize = size;
        textObject.GetComponent<TextMeshPro>().color = color;
        textObject.GetComponent<TextMeshPro>().alignment = TextAlignmentOptions.Center;
        if(font != null)
        {
            textObject.GetComponent<TextMeshPro>().font = font;
        }
        return textObject.GetComponent<TextMeshPro>();
    }
    public static double FloatToDouble(float f)
    {
        decimal dec = new decimal(f);
        double d = (double)dec;
        return d;
    }
}
