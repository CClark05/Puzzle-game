using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameAssets : MonoBehaviour
{
    public static GameAssets i;
    private void Awake()
    {
        if (i == null)
        {
            i = this;
        }
        else
        {
            Destroy(i.gameObject);
        }
    }
    public TMP_FontAsset robotoThin;
    public GameObject tileGrid;
    public GameObject arrows;
    public Sprite[] movementBlocks;
    public Sprite[] portalBlocks;
}
