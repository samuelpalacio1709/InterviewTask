using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PurchaseManager : Singleton<PurchaseManager>
{

    private List<Purchase> purchasedItems = new List<Purchase>();
    private Purchase lastPurchase;

    public Purchase LastPurchase => lastPurchase;

    public void CreatePurchase(ProductSO productInfo)
    {
        Debug.Log("New purchase");
        var purchase = new Purchase(productInfo.iD);
        lastPurchase = purchase;
        purchasedItems.Add(purchase);
    }
}
