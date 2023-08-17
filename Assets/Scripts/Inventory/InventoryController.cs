using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

[RequireComponent(typeof(InventoryUIController))]
public class InventoryController : MonoBehaviour
{
    [SerializeField] float lossPercentageProducT;
    [SerializeField] InventoryUIController inventoryUIController;
    [SerializeField] Transform shelf;
    [SerializeField] GameObject productPrefab;
    private InventoryItem selectedItem;
    private List<InventoryItem> inventoryItems= new List<InventoryItem>();
    private WearablesManager wearablesManager => WearablesManager.Instance;
    private GameManager gameManager => GameManager.Instance;
    private void OnEnable()
    {
        wearablesManager.OnWearableCreated += HandleWearableCreated;
        inventoryUIController.equipButton.onClick.AddListener(Equip);
        inventoryUIController.unEquipButton.onClick.AddListener(UnEquip);
        inventoryUIController.sellButton.onClick.AddListener(Sell);
    }
    private void OnDestroy()
    {
        wearablesManager.OnWearableCreated -= HandleWearableCreated;

    }
    public void UpdateInventory(IWearable wearable)
    {
        var newItem= Instantiate(productPrefab, shelf);
        var inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.FillInfo(wearable);
        inventoryItem.OnSelected += SelectInventoryItem;
        inventoryItems.Add(inventoryItem);
    }

    public void SelectInventoryItem(InventoryItem item)
    {
        if (selectedItem != null)
        {
            selectedItem.Deselect();
        }
        selectedItem = item;
        selectedItem.Select();
        inventoryUIController.SetOptionsState(true);
    }
    private void HandleWearableCreated(IWearable wearable)
    {
        UpdateInventory(wearable);
    }
    private void Equip()
    {
        if (selectedItem == null) return;

        wearablesManager.UseWearable(selectedItem.wearable.ProductInfo.iD);
    }
    private void UnEquip()
    {
        if (selectedItem == null) return;
        selectedItem.wearable.UnEquip(wearablesManager.characterClothesMaterials,
                                    wearablesManager.blankTexture);

    }
    private void Sell()
    {
        if (selectedItem == null) return;
        UnEquip();
        var wearablesDictionary = wearablesManager.wearablesDictionary;
        var idWearable = selectedItem.wearable.ProductInfo.iD;

        if (wearablesDictionary.ContainsKey(idWearable))
        {
            wearablesDictionary.Remove(idWearable);
        }
        gameManager.IncreaseCoins(selectedItem.wearable.
                           ProductInfo.productPrice * lossPercentageProducT);

        Destroy(selectedItem.gameObject);
    }

   
}
