using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ResourceInfo : ScriptableObject
{

    public string ResourceName; 


    public event Action OnPathFinished = delegate { };

    public bool IsFinished { get; }

    public List<Vector3> path;

    public List<ResourceInfo> ingredients;

    public void Initialize()
    {
        SubscribeToIngredients();

    
    }



    private void OnIngredientFinished()
    {



    }

    private void SubscribeToIngredients()
    {

        foreach (var ingredient in ingredients)
        {
            ingredient.OnPathFinished += OnIngredientFinished;
        }
    }



    private void UnSubscribeToIngredients()
    {

        foreach (var ingredient in ingredients)
        {
            ingredient.OnPathFinished -= OnIngredientFinished;
        }


    }





}




public enum transportationMethod { truck, ship, plane, rail}