using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    [SerializeField]    float rotationSpeed = 1f;


    [SerializeField] private float betterpeed;

    public SupplyChainData data;

    [SerializeField] InputActionReference inputActions;


    [SerializeField] InputActionReference rotateActionRef;

    InputAction rotateAction;

    [SerializeField]
    Transform anotherObjectToRotate;


    void OnEnable()
    {
        rotateAction = rotateActionRef.ToInputAction();
        rotateAction.Enable();
        rotateAction.performed += Rotate;
    }

    private void Rotate(InputAction.CallbackContext obj)
    {
        var inputValue = obj.ReadValue<Vector2>();
        var rotationValue = inputValue.x;

        transform.RotateAround(new Vector3(0f, 1f, 0f), rotationSpeed * Time.deltaTime * rotationValue);

    }


    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.MoveTowards(transform.)
        RotateOnSphere();
    }

    public    Vector3 targetPosition;

    public Transform target;
   
    void RotateOnSphere()
    {

     
            transform.position = Vector3.RotateTowards(transform.position, target.position, rotationSpeed * Time.deltaTime, 0f);
        

    }


    private void FixedUpdate()
    {
        
    }
}


[System.Serializable]
public class SupplyChainData
{
    public List<float> units;



}
