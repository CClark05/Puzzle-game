using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public bool beingDragged;
    private SpriteRenderer sr;
    private Color originalColor;
    private Vector2 currentPos;
    private Vector2 previousTile;
    private bool placed = false;
    public static event Action<int> onTileDiscarded;
    public event Action onTilePlaced;
    public static event Action onTilePlaced_Static;
    public static event Action onTileDiscarded_Static;
    public event Action onBeingDragged;
    public event Action onDoneDragged;
    public event Action onScrollUp;
    public event Action onScrollDown;
    public void Awake()
    {
        beingDragged = true;
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        beingDragged = true;
        GameAssets.i.tileGrid.GetComponent<TileGrid>().gridSystem.SetValue(previousTile, 1);
        onBeingDragged?.Invoke();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int value;
        GameAssets.i.tileGrid.GetComponent<TileGrid>().gridSystem.GetValue(currentPos, out value);
        if (beingDragged && value == 1){
            beingDragged = false;
            onDoneDragged?.Invoke();
            GetComponent<EnviromentTile>().UpdateTile();
            previousTile = transform.position;
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    public void Update()
    {
        

        currentPos = transform.position;
        if (beingDragged && !GameManager.i.simulationRun)
        {
            float mouseScroll = Input.GetAxis("Mouse ScrollWheel");
            if (Input.GetKeyDown(KeyCode.Escape) && !placed)
            {
                DiscardBlock();
            }

            if(mouseScroll > 0) //Forward
            {
                onScrollUp?.Invoke();
            }
            if(mouseScroll < 0) //Backwards
            {
                onScrollDown?.Invoke();
            }

            int value;
            GameAssets.i.tileGrid.GetComponent<TileGrid>().gridSystem.GetValue(currentPos, out value);
            if (value == 1) sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);
            else
            {
                sr.color = new Color(1, 0, 0, 0.5f);
                
            }

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
            
            if (Input.GetMouseButtonDown(0))
            {

                if (value == 1)
                {
                    beingDragged = false;
                    onDoneDragged?.Invoke();
                    GetComponent<EnviromentTile>().UpdateTile();
                    previousTile = transform.position;
                    onTilePlaced?.Invoke();
                    onTilePlaced_Static?.Invoke();
                    placed = true;
                }
                else
                {
                    sr.color = originalColor;
                }
            }
        }
        
    }
    public void DiscardBlock ()
    {

        onTileDiscarded?.Invoke(GetComponent<EnviromentTile>().id);
        onTileDiscarded_Static?.Invoke();
        onTilePlaced?.Invoke();
        GameAssets.i.tileGrid.GetComponent<TileGrid>().gridSystem.SetValue(previousTile, 1);
        Destroy(gameObject);

       

    }

    
}
