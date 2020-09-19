using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementBlock : EnviromentTile_Draggable
{

    [SerializeField] private PlayerDirections direction;
    private SpriteRenderer sr;
    new private void Awake()
    {
        base.Awake();
        sr = GetComponent<SpriteRenderer>();
        SetSprite();

        GetComponent<Tile_UI>().onSpriteChangedLeft += MovementBlock_onSpriteChangedLeft;
        GetComponent<Tile_UI>().onSpriteChangedRight += MovementBlock_onSpriteChangedRight;
    }
    
    private void MovementBlock_onSpriteChangedRight()
    {
        int index = (int)direction;
        if ((int)direction < Enum.GetValues(typeof(PlayerDirections)).Length - 1)
        {
            
            index++;
            
        }
        else
        {
            index = 0;
        }
        direction = (PlayerDirections)index;
        SetSprite();
    }

    private void MovementBlock_onSpriteChangedLeft()
    {
        int index = (int)direction;
        if ((int)direction < 1)
        {
            index = Enum.GetValues(typeof(PlayerDirections)).Length - 1;
        }
        else
        {
            index--;
   
        }
        direction = (PlayerDirections)index;
        SetSprite();
    }
    
    new private void Update()
    {
        base.Update();
        if(Vector2.Distance(transform.position, playerTransform.position) < 0.05f && !dragDrop.beingDragged)
        {
            playerTransform.GetComponent<IMovement>().SwitchDirection(direction);
        }
      
        
    }

    public void SetSprite()
    {
        switch (direction)
        {
            case PlayerDirections.right:
                sr.sprite = GameAssets.i.movementBlocks[3];
                break;
            case PlayerDirections.left:
                sr.sprite = GameAssets.i.movementBlocks[2];
                break;
            case PlayerDirections.up:
                sr.sprite = GameAssets.i.movementBlocks[0];
                break;
            case PlayerDirections.down:
                sr.sprite = GameAssets.i.movementBlocks[1];
                break;
        }
    }
}
