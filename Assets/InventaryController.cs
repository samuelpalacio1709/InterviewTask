using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventaryController : MonoBehaviour
{
    public Transform shelf;
    public GameObject productPrefab;
    WearablesManager wearablesManager=> WearablesManager.Instance;
    PurchaseManager purchaseManager=> PurchaseManager.Instance;
    GlobalUIManager globalUIManager=> GlobalUIManager.Instance;

    public void ShowAllProducts()
    {
        foreach (var item in wearablesManager.wearablesDictionary)
        {
            var product = Instantiate(productPrefab);
        }
    }
}
