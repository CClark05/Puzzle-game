using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBlock : MonoBehaviour
{
    public int inventoryIndex;
    public static event Action<int> onTileDiscarded;
    private void Awake()
    {
        GetComponent<DragDrop>().onTileDiscarded += InventoryBlock_onTileDiscarded;
    }

    private void InventoryBlock_onTileDiscarded()
    {
        onTileDiscarded?.Invoke(inventoryIndex);
    }
}
