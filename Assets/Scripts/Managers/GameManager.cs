using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Transform playerTranform;
    public GameState gameState= GameState.Free;
    private float totalCoins=0;
    public static Action<float> onCoinsChanged;
    public float TotalCoins { get => totalCoins; }

    public enum GameState
    {
        Free,
        Shopping,
    }
    public void ChangeState(GameState gameState)
    {
        Debug.Log("----StateChanged----");
        this.gameState = gameState;
    }

    public void IncreaseCoins(float coinValue)
    {
        totalCoins += coinValue;
        onCoinsChanged?.Invoke(totalCoins);
            
     }
    public void  DecreaseCoins(float coinValue)
    {
        totalCoins -= coinValue;
        if (totalCoins < 0) totalCoins = 0;
        onCoinsChanged?.Invoke(totalCoins);
    }
}
