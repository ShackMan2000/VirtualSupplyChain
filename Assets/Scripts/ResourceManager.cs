using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // 
    [SerializeField]
    private List<ResourceInfo> allResources;

    [SerializeField]
    Resource resourcePF;


    private void Start()
    {
        foreach (var r in allResources)
        {
            Resource newResource = Instantiate(resourcePF);
            newResource.Initialize(r);
        }
    }



}
