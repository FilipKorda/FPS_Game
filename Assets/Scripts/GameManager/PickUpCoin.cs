using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        PlayerEQ playereq = other.GetComponent<PlayerEQ>();
        if(playereq != null)
        {
            playereq.CoinColleted();
            Destroy(gameObject);
        }
    }
}
