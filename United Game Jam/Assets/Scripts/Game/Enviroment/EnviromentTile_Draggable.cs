using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnviromentTile_Draggable : EnviromentTile
{
    public DragDrop dragDrop;

    new public void Awake()
    {
        base.Awake();
        dragDrop = GetComponent<DragDrop>();

    }
    double xPos;
    double yPos;
    public void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -8, 9), Mathf.Clamp(transform.position.y, -4, 5));
        Vector2 currentPos = transform.position;

        xPos = Math.Round(currentPos.x, MidpointRounding.AwayFromZero);
        yPos = Math.Round(currentPos.y, MidpointRounding.AwayFromZero);
        transform.position = new Vector2((float)xPos, (float)yPos);
    }
}
