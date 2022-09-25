using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{

    //pops up when the path starts

    //always look at player

    [SerializeField] Image image;


    public void OnServerInitialized()
    {
        
    }


    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }

}
