using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementBlock : EnviromentTile_Draggable
{

    [SerializeField] private PlayerDirections direction;
    new private void Awake()
    {
        base.Awake();
    }



    new private void Update()
    {
        base.Update();
        if(Vector2.Distance(transform.position, playerTransform.position) < 0.05f && !dragDrop.beingDragged)
        {
            playerTransform.GetComponent<IMovement>().SwitchDirection(direction);
        }
        //transform.position = new Vector2(Mathf.Round(currentPos.x * 2) / 2, Mathf.Round(currentPos.y * 2) / 2);
        
    }
}
