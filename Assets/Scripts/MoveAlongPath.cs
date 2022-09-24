using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongPath : MonoBehaviour
{

    [SerializeField] float moveSpeed;

    [SerializeField] AllPaths mainPaths;


    [ContextMenu("StartMoving")]
    void StartMovingAlongPath()
    {
        StartCoroutine(MoveAlongPathRoutine(mainPaths.paths[0]));

    }


    int step;

    [SerializeField] float threshholdToArrive = 0.1f;

    IEnumerator MoveAlongPathRoutine(Path p)
    {
        step = 0;
        //if(step > p.points.Count)



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
