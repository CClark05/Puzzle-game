using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Menu_UI : MonoBehaviour
{
    [SerializeField] private Button_UI playButton;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject titleText;
    private void Awake()
    {
        HelperMethods.FadeIn(1, panel, null);
        HelperMethods.ButtonBehaviour(playButton, 4, () => {
            if (!panel.activeInHierarchy)
            {
                playButton.transform.Find("Text").GetComponent<Animator>().SetTrigger("Transition");
                titleText.GetComponent<Animator>().SetTrigger("Transition");
                HelperMethods.FadeOut(0.7f, panel, () => HelperMethods.SwitchScene(1));
            }
        }, true);

    }
}
