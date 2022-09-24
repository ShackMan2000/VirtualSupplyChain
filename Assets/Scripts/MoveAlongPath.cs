using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongPath : MonoBehaviour
{

    [SerializeField] float moveSpeed;

    [SerializeField] ResourceInfo resource;

    [ContextMenu("StartMoving")]
    void StartMovingAlongPath()
    {
        StartCoroutine(MoveAlongPathRoutine());

    }


    int step;

    [SerializeField] float threshholdToArrive = 0.1f;

    IEnumerator MoveAlongPathRoutine()
    {
        step = 0;

        while (step < p.points.Count)
        {
            Vector3 targetPosition = p.points[step];


            while (Vector3.Distance(transform.position, targetPosition) > threshholdToArrive)
            {
                transform.position = Vector3.RotateTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime, 0f);
                yield return null;
            }

            step++;
        }


    }


}
