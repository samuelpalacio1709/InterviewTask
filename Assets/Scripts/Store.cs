using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour, IInteractable
{
    [SerializeField] StoreController storeController;
    [SerializeField] string welcomeMessage;
    public GlobalUIManager globalUIManager => GlobalUIManager.Instance;
    public GameManager gameManager => GameManager.Instance;
    private bool hasVisitors;
    public void ShowInteraction()
    {
        globalUIManager.ShowStickyMessage(welcomeMessage);
        PlayerInputHandler.OnInputInteraction += Interact;
        hasVisitors=true;
    }
    public void HideInteraction()
    {
        HideMessage();
        hasVisitors = false;
    }
    public void HideMessage()
    {
        globalUIManager.HideStickyMessage();
        PlayerInputHandler.OnInputInteraction -= Interact;
    }

    public void Interact()
    {
        if (storeController != null)
        {
            HideMessage();
            storeController.OpenStore();
            gameManager.ChangeState(GameManager.GameState.Shopping);
            storeController.OnStoreClosed += HandleStoreClosed;
        }
    }

    public void HandleStoreClosed()
    {
        storeController.OnStoreClosed -= HandleStoreClosed;
        gameManager.ChangeState(GameManager.GameState.Free);
        if (hasVisitors)
        {
            ShowInteraction();
        }
        else
        {
            HideInteraction();
        }

    }
}
