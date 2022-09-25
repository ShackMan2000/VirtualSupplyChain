using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct PathPoint 
{
    [SerializeField] Vector3 position;
    public Vector3 Position => position;

    [SerializeField] TransportationType transportationType;
    public TransportationType TransportationType  => transportationType;


    public PathPoint(Vector3 position, TransportationType transportationType)
    {
        this.position = position;
        this.transportationType = transportationType;
    }
}
