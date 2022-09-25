using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ResourceManager : MonoBehaviour
{
    // 
    [SerializeField]
    private List<ResourceInfo> allResources;

    [SerializeField]
    Resource resourcePF;



    [SerializeField] InputActionReference startSimulationRef;

    InputAction startSimulationAction;


    void OnEnable()
    {
        startSimulationAction = startSimulationRef.ToInputAction();
        startSimulationAction.Enable();
        startSimulationAction.performed += StartSimulation;
    }

    private void StartSimulation(InputAction.CallbackContext obj)
    {
        foreach (var r in allResources)
        {
            r.isFinished = false;
            Resource newResource = Instantiate(resourcePF);
            newResource.Initialize(r);
        }
    }






}
