using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] private Transform slotOne;
    [SerializeField] private Inventory inventory;
    private void Awake()
    {
        foreach (var slot in inventory.itemSlots)
        {
            slot.onNumChanged += Slot_onNumChanged;
        }
        slotOne.transform.Find("Image").GetComponent<Image>().sprite = inventory.itemSlots[0].blockPrefab.GetComponent<SpriteRenderer>().sprite;
        slotOne.transform.Find("Image").GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (inventory.itemSlots[0].num > 0)
            {
                GameObject newBlock = Instantiate(inventory.itemSlots[0].blockPrefab);
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                newBlock.transform.position = mousePos;
                inventory.UpdateSlotNum(-1, 0);
                UpdateNumberText(slotOne);
            }
        };
        slotOne.transform.Find("Right Arrow").GetComponent<Button_UI>().ClickFunc = () =>
        {
            inventory.itemSlots[0].UpdateBlockUp();
            slotOne.transform.Find("Image").GetComponent<Image>().sprite = inventory.itemSlots[0].blockPrefab.GetComponent<SpriteRenderer>().sprite;
        };
        slotOne.transform.Find("Left Arrow").GetComponent<Button_UI>().ClickFunc = () =>
        {
            inventory.itemSlots[0].UpdateBlockDown();
            slotOne.transform.Find("Image").GetComponent<Image>().sprite = inventory.itemSlots[0].blockPrefab.GetComponent<SpriteRenderer>().sprite;
        };
        slotOne.transform.Find("Number Text").GetComponent<TextMeshProUGUI>().text = inventory.itemSlots[0].num.ToString();
    }

    private void Slot_onNumChanged(Transform obj)
    {
        UpdateNumberText(obj);
    }

    private void UpdateNumberText(Transform slot)
    {
        slot.transform.Find("Number Text").GetComponent<TextMeshProUGUI>().text = inventory.itemSlots[0].num.ToString();
    }
    
}
