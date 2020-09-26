using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : EnviromentTile
{
    private bool touchedFlag;
    public static event Action onFlagEntered;
    new private void Awake()
    {
        base.Awake();
        touchedFlag = false;
        
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) < 0.05f && !touchedFlag)
        {
            onFlagEntered?.Invoke();
            Debug.Log("Next Level");
            touchedFlag = true;
        }
    }
}
