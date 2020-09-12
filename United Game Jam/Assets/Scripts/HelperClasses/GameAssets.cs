using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameAssets : MonoBehaviour
{
    public static GameAssets i;
    private void Awake()
    {
        i = this;
    }
    public TMP_FontAsset robotoThin;
    public GameObject tileGrid;
}
