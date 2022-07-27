using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    public static Player_Health playerhealth;
    public float currHealth = 100f;
    public float maxHealth = 100;
    public bool isDie = false;
    public Slider healthSlider;
    public Text healthCounter;

    [Header("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    float colorSmoothing = 6f;
    bool isTakingDamage = false;

    public GameObject death_screen;


    private void Awake()
    {
        playerhealth = this;
    }
    

    private void Start() 
    {  
        currHealth = maxHealth;
        UpdateHealthUI();
        
    }

    void Update()
    {
        if(isTakingDamage)
        {
            damageImage.color = damageColor;
        }else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, colorSmoothing * Time.deltaTime);
        }

        isTakingDamage = false;
    }


    public void DamagePlayer(float DMG)
    {
        if(currHealth > 0)
        {
            if(DMG >= currHealth)
            {
                isTakingDamage = true;
                DIE();

            }else
            {
                isTakingDamage = true;
                currHealth -= DMG;
            }
            UpdateHealthUI();
        }
    }

    public void AddHealth(float healthAmmount)
    {
        currHealth += healthAmmount;
        UpdateHealthUI();
    }
            
  
    
    public void UpdateHealthUI()
    {
        healthCounter.text = currHealth.ToString();
        healthSlider.value = currHealth;
    }

    void DIE() 
    {
        death_screen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        currHealth = 0;
        isDie = true;
        healthSlider.value = 0;
        UpdateHealthUI();
        //Time.timeScale = 0f;
        Debug.Log("Player is dead");
    }
}
