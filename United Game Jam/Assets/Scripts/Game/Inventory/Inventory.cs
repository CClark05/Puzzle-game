using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemSlot> itemSlots;
    private void Awake()
    {
        DragDrop.onTileDiscarded += DragDrop_onTileDiscarded;
    }

    private void DragDrop_onTileDiscarded(int id)
    {
        for(var i = 0; i<itemSlots.Count; i++)
        {
            if (itemSlots[i].block == BlockDatabase.GetBlockName(id))
            {
                itemSlots[i].UpdateNum(1);
                return;
            }
        }
    }

    public void UpdateSlotNum(int amount, int index)
    {
        if(index < itemSlots.Count)
        {
            itemSlots[index].UpdateNum(amount);
        }
    }
}
[System.Serializable]
public class ItemSlot
{
    public Blocks block;
    public int num;
    public bool hasOrienations;
    public List<GameObject> blockPrefabs;
    public GameObject blockPrefab;
    private int prefabIndex = 0;
    public event Action<int> onNumChanged;
    public void UpdateBlockUp()
    {
       
        if(prefabIndex < blockPrefabs.Count - 1)
        {
            prefabIndex++;
            
        }
        else
        {
            prefabIndex = 0;
        }
        blockPrefab = blockPrefabs[prefabIndex];
        
    }
    public void UpdateBlockDown()
    {
        if(prefabIndex < 1)
        {
            prefabIndex = blockPrefabs.Count - 1;
        }
        else
        {
            prefabIndex--;
        }
        blockPrefab = blockPrefabs[prefabIndex];
    }
    public void UpdateNum(int amount)
    {
        num += amount;
        onNumChanged?.Invoke(BlockDatabase.GetBlockID(block));
    }
}