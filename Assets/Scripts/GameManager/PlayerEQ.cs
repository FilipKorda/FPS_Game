using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEQ : MonoBehaviour
{
    public int NumberOfCoin {get; private set;}
    public UnityEvent<PlayerEQ> OnCoinColleted;

    public void CoinColleted()
    {
        NumberOfCoin++;
        OnCoinColleted.Invoke(this);
    }
}
