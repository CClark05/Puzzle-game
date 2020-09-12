using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;
using TMPro;

public class GridSystem 
{
    public int height;
    public int width;
    public float cellSize;
    public int[,] gridArray;
    private TextMeshPro[,] textArray;
    private Vector2 offsetVector;
    private Transform textParent;
    public bool showText;
    public GridSystem(int width, int height, Vector2 offsetVector, float cellSize, Transform textParent)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.offsetVector = offsetVector;
        this.textParent = textParent;
        gridArray = new int[width, height];
        textArray = new TextMeshPro[width, height];
        for(var w = 0; w < gridArray.GetLength(0); w++)
        {
            for(var h = 0; h < gridArray.GetLength(1); h++)
            {
               textArray[w, h] = HelperMethods.CreateText(textParent, "0", (GetPosition(w, h) + offsetVector) + new Vector2(cellSize, cellSize) * 0.5f, 5, GameAssets.i.robotoThin, Color.red);
               Debug.DrawLine(GetPosition(w, h) + offsetVector, GetPosition(w, h + 1) + offsetVector, Color.red, 100);
               Debug.DrawLine(GetPosition(w, h) + offsetVector, GetPosition(w + 1, h) + offsetVector, Color.red, 100);
                textArray[w, h].gameObject.SetActive(false);
            }
        }
        Debug.DrawLine(GetPosition(0, height) + offsetVector, GetPosition(width, height) + offsetVector, Color.red, 100);
        Debug.DrawLine(GetPosition(width, 0) + offsetVector, GetPosition(width, height) + offsetVector, Color.red, 100);
        
    }
    private Vector2 GetPosition(int x, int y)
    {
        return new Vector2(x, y) * cellSize;
    }
    public void SetValue(int x, int y, int value)
    {
        textArray[x , y].text = value.ToString();
    }
    public void GetValue(Vector2 position, out int value)
    {
        int x;
        int y;
        GetCords(position, out x, out y);
        Int32.TryParse(textArray[x, y].text, out value);
        
    }
    public void SetValue(Vector2 position, int value)
    {
        int x;
        int y;
        GetCords(position, out x, out y);
        textArray[x, y].text = value.ToString();
    }
    private void GetCords(Vector2 position, out int x, out int y)
    {
        x = Mathf.FloorToInt((position.x / cellSize) - offsetVector.x);
        y = Mathf.FloorToInt((position.y / cellSize) - offsetVector.y);
    }
    //Debug Text
    public void HideText()
    {
        showText = false;
        for (var w = 0; w < gridArray.GetLength(0); w++)
        {
            for (var h = 0; h < gridArray.GetLength(1); h++)
            {
                textArray[w, h].gameObject.SetActive(false);
            }
        }
    }
    public void ShowText()
    {
        showText = true;
        for (var w = 0; w < gridArray.GetLength(0); w++)
        {
            for (var h = 0; h < gridArray.GetLength(1); h++)
            {
                textArray[w, h].gameObject.SetActive(true);
            }
        }
    }
}
