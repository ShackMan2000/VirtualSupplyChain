using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ResourceInfo : ScriptableObject
{

    public string ResourceName;

    public Sprite iconImage;


    [NonReorderable]
    public List<PathPoint> path;

    public List<ResourceInfo> ingredients;


    public event Action OnPathFinished = delegate { };




    public void InvokePathFinished()
    {
        OnPathFinished();
    }

    internal void AddPointToPath(Vector3 position, TransportationType transportationType)
    {
        path.Add(new PathPoint(position, transportationType));
    }
}



