using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour, IInteractable
{
    [SerializeField] float coinValue;
    GameManager gameManager => GameManager.Instance;
    public void Interact()
    {
        gameManager.IncreaseCoins(coinValue);
        this.gameObject.SetActive(false);
    }

    public void ShowInteraction()
    {
        Interact();
    }
    public void HideInteraction()
    {
        this.gameObject.SetActive(false);
    }
}
