using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTile : EnviromentTile_Draggable
{
    public enum Colors
    {
        Red,
        Cyan,
    }
    [SerializeField] private GameObject connectingPortal;
    public Colors color;
    private float teleportDelay = 0.5f;
    private float teleportTimer;
    [HideInInspector] public bool countDown;
    [HideInInspector] public bool connected;
    private SpriteRenderer sr;
    new private void Awake()
    {
        base.Awake();
        sr = GetComponent<SpriteRenderer>();
        GetComponent<DragDrop>().onTilePlaced += FindPortal;
        teleportTimer = teleportDelay;
        GetComponent<Tile_UI>().onSpriteChangedLeft += PortalTile_onSpriteChangedLeft;
        GetComponent<Tile_UI>().onSpriteChangedRight += PortalTile_onSpriteChangedRight;
        UpdateSprite();
    }

    private void PortalTile_onSpriteChangedRight()
    {
        int index = (int)color;
        if ((int)color < Enum.GetValues(typeof(Colors)).Length - 1)
        {

            index++;

        }
        else
        {
            index = 0;
        }
        color = (Colors)index;
        UpdateSprite();
        FindPortal();
    }

    private void PortalTile_onSpriteChangedLeft()
    {
        int index = (int)color;
        if ((int)color < 1)
        {
            index = Enum.GetValues(typeof(Colors)).Length - 1;
        }
        else
        {
            index--;

        }
        color = (Colors)index;
        UpdateSprite();
        FindPortal();
    }
    
    new private void Update()
    {
        base.Update();
        if (Vector2.Distance(transform.position, playerTransform.position) < 0.05f && !dragDrop.beingDragged)
        {
            if (connectingPortal != null && !connectingPortal.GetComponent<PortalTile>().countDown)
            {
                playerTransform.position = connectingPortal.transform.position;
                countDown = true;
            }
        }

        if (countDown)
        {
            teleportTimer -= Time.deltaTime;
            if(teleportTimer <= 0)
            {
                teleportTimer = teleportDelay;
                countDown = false;
            }
        }
    }
    
    private void FindPortal()
    {
        
        GameObject[] availablePortals = GameObject.FindGameObjectsWithTag(this.tag);
        
        List<GameObject> portalsList = new List<GameObject>();
        if(availablePortals.Length == 1){

            if (connectingPortal != null)
            {
                connectingPortal.GetComponent<PortalTile>().connectingPortal = null;
                connectingPortal.GetComponent<PortalTile>().connected = false;
            }
            connectingPortal = null;
            connected = false;
            return;
        }
        else if (availablePortals.Length > 1)
        {
            portalsList.AddRange(availablePortals);
            for (var i = 0; i < portalsList.Count; i++)
            {
                if (portalsList[i].GetComponent<PortalTile>().connected)
                {
                    portalsList.RemoveAt(i);
                    i--;
                }
            }
            if (portalsList.Count > 1)
            {
                int rand = UnityEngine.Random.Range(0, portalsList.Count - 1);

                if (portalsList != null && portalsList[rand] != this.gameObject && portalsList[rand].GetComponent<PortalTile>().color == this.color)
                {

                    connectingPortal = portalsList[rand];
                    connectingPortal.GetComponent<PortalTile>().connectingPortal = this.gameObject;
                    connected = true;
                    connectingPortal.GetComponent<PortalTile>().connected = true;

                }
            }
            else
            {
                if (connectingPortal != null)
                {
                    connectingPortal.GetComponent<PortalTile>().connectingPortal = null;
                    connectingPortal.GetComponent<PortalTile>().connected = false;
                }
                connected = false;
                connectingPortal = null;
                
            }
        }
        
        
    }
    
    private void UpdateSprite()
    {
        switch (color)
        {
            case Colors.Cyan:
                sr.sprite = GameAssets.i.portalBlocks[0];
                gameObject.tag = "Portal(Cyan)";
                break;
            case Colors.Red:
                sr.sprite = GameAssets.i.portalBlocks[1];
                gameObject.tag = "Portal(Red)";
                break;
                
        }
    }

    private void OnDestroy()
    {
        
    }
}


