using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileDetection : MonoBehaviour
{
    Ray ray;
    RaycastHit2D hit;
    string raycastHit;
    public void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        raycastHit = RaycastCheck(ray, hit);

    }
    public string GetRaycastName()
    {
        return raycastHit;
    }
    public string RaycastCheck(Ray ray, RaycastHit2D hit)
    {
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, ~9))
        {
            return hit.collider.name;
        }
        else
        {
            return null;
        }
    }
}
