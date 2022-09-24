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
       // StartCoroutine(MoveAlongPathRoutine());

    }


    int step;

    [SerializeField] float threshholdToArrive = 0.1f;




}
