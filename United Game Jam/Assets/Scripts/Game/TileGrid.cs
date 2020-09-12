using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid : MonoBehaviour
{
    public GridSystem gridSystem;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private Transform textParent;
    private void Awake()
    {
        gridSystem = new GridSystem(18, 10, new Vector2(xOffset, yOffset), 1, textParent);
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            if (!gridSystem.showText)
                gridSystem.ShowText();
            else
            {
                gridSystem.HideText();
            }
        }
    }
}
