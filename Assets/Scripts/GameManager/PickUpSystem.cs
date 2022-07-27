using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpSystem : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public float pickupDistace = 5f;
    Camera mainCAM;
    public Text pickupText;
    public LayerMask layer;
    string pickupInfo;

    void Start() 
    {
        mainCAM = Camera.main;
    }

    void Update() 
    {
        ray = mainCAM.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        if(Physics.Raycast(ray, out hit, pickupDistace, layer))
        {
            pickupText.enabled = true;
            pickupText.text = hit.transform.name.ToString();
            if(hit.transform.tag == "HealthPack")
            {
                if(Player_Health.playerhealth.currHealth < Player_Health.playerhealth.maxHealth)
                {
                    PickupHealth();
                }else
                {
                    pickupInfo = "Health Full";
                    pickupText.text = pickupInfo;
                }
                
            }
        }
        else
            {
                pickupText.enabled = false;
            }
        
    }

    void PickupHealth()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Health_Pack health_Pack_Script = hit.transform.GetComponent<Health_Pack>();
            float healthAmmount = health_Pack_Script.healthAmmount;
            if(Player_Health.playerhealth.currHealth + healthAmmount > Player_Health.playerhealth.maxHealth)
            {
                Player_Health.playerhealth.currHealth = Player_Health.playerhealth.maxHealth;
                Player_Health.playerhealth.UpdateHealthUI();
            }else
            { 
                Player_Health.playerhealth.AddHealth(healthAmmount);
            }
            Destroy(hit.transform.gameObject);
            pickupText.enabled = false;
        }
        
        
    }
}

