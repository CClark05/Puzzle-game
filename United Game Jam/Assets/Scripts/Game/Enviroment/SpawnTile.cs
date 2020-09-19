using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using CodeMonkey.Utils;

public class SpawnTile : EnviromentTile
{
    [SerializeField] private PlayerDirections direction;
    private int directionIndex;
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer sr;
    [SerializeField] private Button_Sprite rightArrow;
    [SerializeField] private Button_Sprite leftArrow;

    new private void Awake()
    {
        directionIndex = (int)direction;
        base.Awake();
        sr = GetComponent<SpriteRenderer>();
        Game_UI.onPlayButtonClicked += StartGame;
        FindSprite();
        rightArrow.ClickFunc = () =>
        {
            if (directionIndex < Enum.GetValues(typeof(PlayerDirections)).Length - 1)
            {
                directionIndex++;
            }
            else
            {
                directionIndex = 0;
            }
            UpdateDirection();
        };
        leftArrow.ClickFunc = () =>
        {
            if (directionIndex < 1)
            {
                directionIndex = Enum.GetValues(typeof(PlayerDirections)).Length - 1;
            }
            else
            {
                directionIndex--;
            }
            UpdateDirection();
        };
        GameManager.onSimulationRun += () =>
        {
            rightArrow.gameObject.SetActive(false);
            leftArrow.gameObject.SetActive(false);
        };
        GameManager.onSimulationRestarted += () =>
        {
            rightArrow.gameObject.SetActive(true);
            leftArrow.gameObject.SetActive(true);
        };


    }
    private void FindSprite()
    {
        switch (direction)
        {
            case PlayerDirections.up:
                sr.sprite = sprites[0];
                break;
            case PlayerDirections.down:
                sr.sprite = sprites[1];
                break;
            case PlayerDirections.left:
                sr.sprite = sprites[2];
                break;
            case PlayerDirections.right:
                sr.sprite = sprites[3];
                break;
        }
    }
    private void StartGame()
    {
        playerTransform.GetComponent<IMovement>().SwitchDirection(direction);
    }

    private void UpdateDirection()
    {
        direction = (PlayerDirections)directionIndex;
        FindSprite();
    }

}
