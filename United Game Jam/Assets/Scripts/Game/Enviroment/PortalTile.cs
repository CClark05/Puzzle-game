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
    new private void Awake()
    {
        base.Awake();
        GetComponent<DragDrop>().onTilePlaced += FindPortal;
        teleportTimer = teleportDelay;
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
       portalsList.AddRange(availablePortals);

       for(var i = 0; i < portalsList.Count; i++)
       {
           if (portalsList[i].GetComponent<PortalTile>().connected)
           {
                portalsList.RemoveAt(i);
                i--;
           }
       }

       int rand = Random.Range(0, portalsList.Count - 1);
       if (portalsList != null && portalsList[rand] != this.gameObject && portalsList[rand].GetComponent<PortalTile>().color == this.color)
       {
            connectingPortal = portalsList[rand];
            connectingPortal.GetComponent<PortalTile>().connectingPortal = this.gameObject;
            connected = true;
            connectingPortal.GetComponent<PortalTile>().connected = true;
       }
        
    }
}
