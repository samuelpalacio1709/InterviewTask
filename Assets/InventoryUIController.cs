using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    [SerializeField] Button sellButton;
    [SerializeField] Button equipButton;
    [SerializeField] Button unEquipButton;
    [SerializeField] Button closeInventoryButton;
    [SerializeField] Button inventoryButton;
    [SerializeField] GameObject inventoryCanvasObject;

    private void OnEnable()
    {
        closeInventoryButton.onClick.AddListener(()=> SetInventoryState(false));
        inventoryButton.onClick.AddListener(()=> SetInventoryState(true));
    }


    private void SetInventoryState(bool state)
    {
        inventoryCanvasObject.SetActive(state);
    }

}
