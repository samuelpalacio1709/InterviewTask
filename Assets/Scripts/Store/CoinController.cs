using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour, IInteractable
{
    [SerializeField] float coinValue;
    GameManager gameManager => GameManager.Instance;
    GlobalUIManager globalUIManager => GlobalUIManager.Instance;

    public void Interact()
    {
        var totalCoins= gameManager.IncreaseCoins(coinValue);
        globalUIManager.UpdateCoinsUI(totalCoins);
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
