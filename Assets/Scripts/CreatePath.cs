using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePath : MonoBehaviour
{
    //click, shoot a raycast, hit only planet
    //save point

    //add point to path

    [SerializeField] Transform pointVisualPF;


    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.GetComponent<Move>())
            {
                var hitPosition = hit.point;
                var newVisual = Instantiate(pointVisualPF, transform);
            }
        }

    }
}
