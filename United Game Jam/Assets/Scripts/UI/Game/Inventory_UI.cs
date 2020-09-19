using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] private List<Transform> slots;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject slotPrefab;
    private bool tileSelected;
    private void Awake()
    {
        for(var i = 0; i < inventory.itemSlots.Count; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab);
            newSlot.transform.parent = transform;
            newSlot.transform.localScale = new Vector3(1, 1, 1);
        }
        foreach (Transform child in transform)
        {
            slots.Add(child);
        }
        DragDrop.onTilePlaced_Static += DragDrop_onTilePlaced_Static;
        DragDrop.onTileDiscarded_Static += DragDrop_onTilePlaced_Static;
    }

    private void DragDrop_onTilePlaced_Static()
    {
        tileSelected = false;
    }

    private void Start()
    {
        SetupSlots();
        
    }

    private void Slot_onNumChanged(int id)
    {
        for(var i = 0; i < slots.Count; i++)
        {
            if(inventory.itemSlots[i].block == BlockDatabase.GetBlockName(id))
            {
                slots[i].transform.Find("Number Text").GetComponent<TextMeshProUGUI>().text = inventory.itemSlots[i].num.ToString();
                return;
            }
        }
    }

    private void SetupSlots()
    {
        
            for (int i = 0; i < slots.Count; i++)
            {
                inventory.itemSlots[i].onNumChanged += Slot_onNumChanged;
                slots[i].transform.Find("Image").GetComponent<Image>().sprite = inventory.itemSlots[i].blockPrefab.GetComponent<SpriteRenderer>().sprite;
                SetupButton(i);
                slots[i].transform.Find("Number Text").GetComponent<TextMeshProUGUI>().text = inventory.itemSlots[i].num.ToString();
            }
            
    }
    
    private void SetupButton(int index)
    {
        slots[index].transform.Find("Image").GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (inventory.itemSlots[index].num > 0 && !tileSelected && !GameManager.i.simulationRun)
            {
                GameObject newBlock = Instantiate(inventory.itemSlots[index].blockPrefab);
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newBlock.transform.position = mousePos;
                inventory.UpdateSlotNum(-1, index);
                slots[index].transform.Find("Number Text").GetComponent<TextMeshProUGUI>().text = inventory.itemSlots[index].num.ToString();
                tileSelected = true;
            }

        };

        slots[index].transform.Find("Right Arrow").GetComponent<Button_UI>().ClickFunc = () =>
        {
            
            inventory.itemSlots[index].UpdateBlockUp();
            slots[index].transform.Find("Image").GetComponent<Image>().sprite = inventory.itemSlots[index].blockPrefab.GetComponent<SpriteRenderer>().sprite;
            
        };

        slots[index].transform.Find("Left Arrow").GetComponent<Button_UI>().ClickFunc = () =>
        {
            
            inventory.itemSlots[index].UpdateBlockDown();
             slots[index].transform.Find("Image").GetComponent<Image>().sprite = inventory.itemSlots[index].blockPrefab.GetComponent<SpriteRenderer>().sprite;
            
        };
    }
    
}
