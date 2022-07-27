using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EQUI : MonoBehaviour
{
    private Text Cointext;

    private void Start() 
    {
        Cointext = GetComponent<Text>();    
    }

    public void UpdateCoinText(PlayerEQ playereq)
    {
        Cointext.text = playereq.NumberOfCoin.ToString();
    }
}
