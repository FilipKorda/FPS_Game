using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{

    public GameObject FPCamera;

   
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            FPCamera.GetComponent<Animator>().Play("AimIN");
        }

        if(Input.GetMouseButtonUp(1))
        {
            FPCamera.GetComponent<Animator>().Play("IDLE");
        }
    }
}