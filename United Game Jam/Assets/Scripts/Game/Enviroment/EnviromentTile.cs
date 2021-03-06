﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentTile : MonoBehaviour
{
    public int id;
    [HideInInspector] public Transform playerTransform;

    public void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (GetComponent<DragDrop>() == null)
        {
            UpdateTile();
        }

    }

    public void UpdateTile()
    {
        GameAssets.i.tileGrid.GetComponent<TileGrid>().gridSystem.SetValue((Vector2)transform.position, id);
    }
}
