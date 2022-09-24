using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePath : MonoBehaviour
{
  

    [SerializeField] Transform pointVisualPF;
    [SerializeField] Camera cam;

    [SerializeField] AllPaths allPaths;



    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("hit");
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
        allPaths.AddPointToCurrentPath(position);


    }

}
