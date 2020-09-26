using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;

public class Tile_UI : TileDetection
{
    private Button_Sprite spriteButton;
    private bool arrowsShown;
    public event Action onSpriteChangedLeft;
    public event Action onSpriteChangedRight;
    public static Tile_UI selectedTile = null;
    public GameObject newArrows;
    private bool selected;
    private void Awake()
    {
        spriteButton = GetComponent<Button_Sprite>();
        GetComponent<BoxCollider2D>().enabled = false;

        newArrows = Instantiate(GameAssets.i.arrows);
        newArrows.transform.parent = transform;
        newArrows.SetActive(false);
        GameManager.onSimulationRestarted += GameManager_onSimulationRestarted;
        GameManager.onSimulationRun += GameManager_onSimulationRun;
        GetComponent<DragDrop>().onTilePlaced += Tile_UI_onTilePlaced;
        GetComponent<DragDrop>().onScrollDown += SpriteChangedLeft;
        GetComponent<DragDrop>().onScrollUp += SpriteChangedRight;
        Game_UI.onDiscardButtonClicked += Game_UI_onDiscardButtonClicked;

        SetupButton();
        Game_UI.i.HideButton("Discard Button");
    }



    private void GameManager_onSimulationRun()
    {
        if(newArrows != null)
        newArrows.SetActive(false);
    }

    private void GameManager_onSimulationRestarted()
    {
        if(arrowsShown)
        selectedTile.newArrows.SetActive(true);
    }

    private void Game_UI_onDiscardButtonClicked()
    {
        if (selectedTile != null)
        {
            selectedTile.GetComponent<DragDrop>().DiscardBlock();
            selectedTile = null;
            Game_UI.i.HideButton("Discard Button");
            
        }
        
    }

    private void Tile_UI_onTilePlaced()
    {
        GetComponent<BoxCollider2D>().enabled = true;
    }
    new private void Update()
    {
        base.Update();

        if (Input.GetMouseButtonDown(0))
        {
            if (selectedTile != null && !selectedTile.GetComponent<DragDrop>().beingDragged && selected)
            {
                if (GetRaycastName() == null)
                {
                    newArrows.SetActive(false);
                    arrowsShown = false;
                    selected = false;
                    FunctionTimer.Create(() =>
                    {
                        Game_UI.i.HideButton("Discard Button");
                    }, 0.1f);
                }
            }
        }

    }

    private void SetupButton()
    {

        spriteButton.ClickFunc = () =>
        {
            if (!GameManager.i.simulationRun)
            {
                if (selectedTile != null && selectedTile != this)
                {

                    selectedTile.newArrows.SetActive(false);
                    selectedTile.arrowsShown = false;
                    selectedTile = this;

                }
                else
                {
                    selectedTile = this;
                }
                if (!selectedTile.GetComponent<DragDrop>().beingDragged)
                {
                    if (!arrowsShown)
                    {
                        Game_UI.i.ShowButton("Discard Button");
                        newArrows.SetActive(true);
                        arrowsShown = true;
                        FunctionTimer.Create(() =>
                        {
                            selected = true;
                        }, 0.1f);

                    }
                    selectedTile.GetComponent<DragDrop>().onBeingDragged += Tile_UI_onBeingDragged;
                    selectedTile.GetComponent<DragDrop>().onDoneDragged += Tile_UI_onDoneDragged;
                }
            };

            newArrows.transform.Find("Left Arrow").GetComponent<Button_Sprite>().ClickFunc = () =>
            {
                SpriteChangedLeft();
            };

            newArrows.transform.Find("Right Arrow").GetComponent<Button_Sprite>().ClickFunc = () =>
            {
                SpriteChangedRight();
            };
        };
    }

    private void Tile_UI_onDoneDragged()
    {
        selectedTile.newArrows.SetActive(true);
        Game_UI.i.ShowButton("Discard Button");
    }

    private void Tile_UI_onBeingDragged()
    {
        selectedTile.newArrows.SetActive(false);
    }

    private void SpriteChangedLeft()
    {
        if (!GameManager.i.simulationRun)
            onSpriteChangedLeft?.Invoke();
    }
    private void SpriteChangedRight()
    {
        if (!GameManager.i.simulationRun)
            onSpriteChangedRight?.Invoke();
    }


    
}
