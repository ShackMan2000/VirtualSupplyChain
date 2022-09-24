using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ResourceInfo : ScriptableObject
{

    public string ResourceName;

    public List<Vector3> path;

    public List<ResourceInfo> ingredients;

    public TransportationMethod transportationMethod;

    public event Action OnPathFinished = delegate { };




    public void InvokePathFinished()
    {
        OnPathFinished();
    }

    internal void AddPointToPath(Vector3 position)
    {
        path.Add(position);
    }
}




public enum TransportationMethod { truck, ship, plane, rail }