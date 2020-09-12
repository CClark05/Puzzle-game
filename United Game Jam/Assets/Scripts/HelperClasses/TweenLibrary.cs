using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public static class TweenLibrary
{

    public static void LeanTweenValue(GameObject obj, Action<float, float> valueCallback, float startingValue, float endingValue, float duration, Action onFinished)
    {
        LeanTween.value(obj, valueCallback, startingValue, endingValue, duration).setOnComplete(onFinished);
    }

    public static void LeanFadeText(GameObject obj, TextMeshProUGUI txt, float startValue, float endValue, float duration, Action onFinished)
    {
        void floatParameters(float f, float f2)
        {
            txt.color = new Color(txt.color.r, txt.color.g, txt.color.b, f);
        }
        LeanTweenValue(obj, floatParameters, startValue, endValue, duration, onFinished);

    }
    public static void LeanFadeUI_Image(GameObject obj, Image image, float startValue, float endValue, float duration, Action onFinished)
    {
        void floatParameters(float f, float f2)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, f);
        }
        LeanTweenValue(obj, floatParameters, startValue, endValue, duration, onFinished);
    }

    public static void FadeForDuration(GameObject obj, float duration, float waitDuration, float fadeTo, float originalAlpha)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, originalAlpha);
        LeanTween.alpha(obj, fadeTo, duration).setOnComplete(FadeBack);
        void FadeBack()
        {
            LeanTween.alpha(obj, 0, duration).setDelay(waitDuration);
        }
    }
    public static void FadeImage(GameObject obj, float start, float end, float duration, Action onFinished)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, start);
        LeanTween.alpha(obj, end, duration).setOnComplete(onFinished);
    }
    public static void FadeToColorImage(GameObject obj, Color start, Color end, float duration, Action onFinished)
    {
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        sr.color = start;
        LeanTween.color(obj, end, duration).setOnComplete(onFinished);

    }
}

