using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash_Lights : MonoBehaviour
{
    
    public GameObject flash_lights;

    private bool FlashLightActive = false;


    void Start() 
    {
        flash_lights.gameObject.SetActive(false);
    }
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(FlashLightActive == false)
            {
                flash_lights.gameObject.SetActive(true);
                FlashLightActive = true;
            }else
            {
                flash_lights.gameObject.SetActive(false);
                FlashLightActive = false;
            }
            
        }
    }
}
