using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{

    [SerializeField] float moveSpeed;

    [SerializeField] ResourceInfo info;


    List<Vector3> path => info.path;

    List<ResourceInfo> ingredients => info.ingredients;

    public bool IsFinished { get; }


    [SerializeField] float threshholdToArrive = 0.1f;


    public void Initialize(ResourceInfo newInfo)
    {
        info = newInfo;


        if (ingredients == null || ingredients.Count == 0)
        StartCoroutine(MoveAlongPathRoutine());
        else
            SubscribeToIngredients();

    }





   


    IEnumerator MoveAlongPathRoutine()
    {
       int step = 0;

        while (step < path.Count)
        {
            Vector3 targetPosition = path[step];


            while (Vector3.Distance(transform.position, targetPosition) > threshholdToArrive)
            {
                transform.position = Vector3.RotateTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime, 0f);
                yield return null;
            }

            step++;
        }

        info.InvokePathFinished();
    }






    private void OnIngredientFinished()
    {

        StartCoroutine(MoveAlongPathRoutine());

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
