using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSetter : MonoBehaviour
{


    [SerializeField] Transform pointVisualPF;
    [SerializeField] Camera cam;

    [SerializeField] ResourceInfo resource;

    [SerializeField] TransportationType transportationType;



    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.GetComponent<Planet>())
                {
                    var hitPosition = hit.point;
                    var newVisual = Instantiate(pointVisualPF, hit.transform);
                    newVisual.position = hitPosition;
                    AddPointToPath(hitPosition);
                }
            }
        }
    }



    void AddPointToPath(Vector3 position)
    {
        resource.AddPointToPath(position, transportationType);
    }


    [ContextMenu("ShowPath")]
    void ShowPath()
    {
        for (int i = 0; i < resource.path.Count; i++)
        {
           Transform t =  Instantiate(pointVisualPF);
            t.position = resource.path[i].Position;
        }
    }
}
