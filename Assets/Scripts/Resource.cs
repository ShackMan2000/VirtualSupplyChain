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

    public bool IsFinished { get; set; }


    [SerializeField] Icon icon;

    Dictionary<TransportationType, GameObject> models;

    [SerializeField] float threshholdToArrive = 0.1f;


    Transform modelTransform;

    public void Initialize(ResourceInfo newInfo)
    {
        info = newInfo;

        models = new Dictionary<TransportationType, GameObject>();

        if (ingredients == null || ingredients.Count == 0)
            StartCoroutine(MoveAlongPathRoutine());
        else
            SubscribeToIngredients();
    }

    public int step;

    IEnumerator MoveAlongPathRoutine()
    {
        TransportationType previousTransportationType = null;

        if (path.Count > 0)
            transform.position = path[0].Position;

        step = 1;

        while (step < path.Count)
        {
            Vector3 targetPosition = path[step].Position;

            UpdateTransportationMethod();

            while (Vector3.Distance(transform.position, targetPosition) > threshholdToArrive)
            {
                transform.position = Vector3.RotateTowards(transform.position, targetPosition, speed * Time.deltaTime, 0f);


                transform.LookAt(Vector3.zero);
                transform.Rotate(-90, 0, 0);

                var modelRotation = modelTransform.localEulerAngles;
                modelTransform.LookAt(targetPosition);

                modelTransform.localEulerAngles = new Vector3(modelRotation.x, modelTransform.localEulerAngles.y, modelRotation.z);

                // modelTransform.LookAt(targetPosition);
                yield return null;
            }

            step++;
        }

        info.isFinished = true;
        info.InvokePathFinished();
        if (modelTransform != null)
            modelTransform.gameObject.SetActive(false);


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
                modelTransform = models[t].transform;

                models[t].SetActive(true);
            }
            else
            {
                GameObject newModel = Instantiate(t.ModelPrefab, transform);
                modelTransform = newModel.transform;
                models.Add(t, newModel);
            }

        }
    }






    private void OnIngredientFinished()
    {
        bool allFinished = true;

        foreach (var i in ingredients)
        {
            if (!i.isFinished)
                allFinished = false;
        }

        if (allFinished)
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
