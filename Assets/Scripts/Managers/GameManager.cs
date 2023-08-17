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
}
