using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{

    float speed;

    [SerializeField] ResourceInfo info;


    List<PathPoint> path => info.path;

    List<ResourceInfo> ingredients => info.ingredients;

    public bool IsFinished { get; }


    Dictionary<TransportationType, GameObject> models;

    [SerializeField] float threshholdToArrive = 0.1f;


    public void Initialize(ResourceInfo newInfo)
    {
        info = newInfo;

        models = new Dictionary<TransportationType, GameObject>();

        if (ingredients == null || ingredients.Count == 0)
            StartCoroutine(MoveAlongPathRoutine());
        else
            SubscribeToIngredients();

    }




    



    IEnumerator MoveAlongPathRoutine()
    {
        TransportationType previousTransportationType = null;

        if (path.Count > 0)
            transform.position = path[0].Position;

        int step = 1;

        while (step < path.Count)
        {
            Vector3 targetPosition = path[step].Position;

            UpdateTransportationMethod();

            while (Vector3.Distance(transform.position, targetPosition) > threshholdToArrive)
            {
                transform.position = Vector3.RotateTowards(transform.position, targetPosition, speed * Time.deltaTime, 0f);
                yield return null;
            }

            step++;
        }

        info.InvokePathFinished();


        void UpdateTransportationMethod()
        {
            TransportationType t = path[step].TransportationType;

            //same as before, no need to update anything
            if (previousTransportationType == t)
                return;

            speed = t.TravelSpeed;

            foreach (var m in models)            
                m.Value.SetActive(false);
            
            if (models.ContainsKey(t))
            {
                models[t].SetActive(true);
            }
            else
            {
                GameObject newModel = Instantiate(t.ModelPrefab, transform);
                models.Add(t, newModel);
            }

        }
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
