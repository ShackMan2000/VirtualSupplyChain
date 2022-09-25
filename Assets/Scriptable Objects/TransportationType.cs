using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class TransportationType : ScriptableObject
{

    [SerializeField]
    private string transportationName;
    public string TransportationName { get => transportationName; }


    [SerializeField]
    private GameObject model;
    public GameObject ModelPrefab { get => model; }


    [SerializeField]
    private float travelSpeed;
    public float TravelSpeed { get => travelSpeed; }



}
