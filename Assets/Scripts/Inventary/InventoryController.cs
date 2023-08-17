using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InventoryUIController))]
public class InventoryController : MonoBehaviour
{
    public Transform shelf;
    public GameObject productPrefab;
    private List<IWearable> inventoryItems = new List<IWearable>();
    private IWearable selectedWearable;

    public void UpdateInventory(IWearable wearablesManager)
    {
        selectedWearable=wearablesManager;
        inventoryItems.Add(selectedWearable);
        Instantiate(productPrefab, shelf);
    }
}
