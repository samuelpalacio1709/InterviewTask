using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] public Button sellButton;
    [SerializeField] public Button equipButton;
    [SerializeField] public Button unEquipButton;
    [SerializeField] Button closeInventoryButton;
    [SerializeField] Button inventoryButton;
    [SerializeField] GameObject inventoryCanvasObject;

    GameManager gameManager => GameManager.Instance;
    private void OnEnable()
    {
        closeInventoryButton.onClick.AddListener(()=> SetInventoryState(false));
        inventoryButton.onClick.AddListener(()=> SetInventoryState(true));
    }


    private void SetInventoryState(bool state)
    {
        if (gameManager.gameState == GameManager.GameState.Shopping) return;
        inventoryCanvasObject.SetActive(state);
        if (state)
        {
            gameManager.ChangeState(GameManager.GameState.Inventory);
        }
        else
        {
            gameManager.ChangeState(GameManager.GameState.Free);

        }

    }

    public void SetOptionsState(bool state)
    {
       sellButton.interactable=state;
       equipButton.interactable = state;
       unEquipButton.interactable = state;
    }

}
