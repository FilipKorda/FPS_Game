using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public float enemyHealth = 100f;
    public GameObject CoinModel;
    private EnemyAnimation Enemy_Anim;


    

    private void Awake()
    {
        Enemy_Anim = GetComponent<EnemyAnimation>();
    }

    public void CurrentHealth(float currenthealth)
    {
        enemyHealth -= currenthealth;
    }

    

    public void ApplyDamage(float damage)
    {   
        enemyHealth -= damage;

        if (enemyHealth <= 0f)
        {
            EnemyDeath();                    
        }


    }
    void DropCoin()
    {          
        Instantiate(CoinModel, transform.position, Quaternion.identity);
    }

    void EnemyDeath()
    {
        Enemy_Anim.Dead();       
        Destroy(this.gameObject, 1f);
        DropCoin();       
    }
}
