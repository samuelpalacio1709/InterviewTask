using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PurchaseManager : Singleton<PurchaseManager>
{

    private Stack<Purchase> purchasedItems = new Stack<Purchase>();
    private Purchase lastPurchase;

    public Purchase LastPurchase => purchasedItems.Peek();

    public void CreatePurchase(IProduct product)
    {
        var purchase = new Purchase(product.ProductInfo);
        purchasedItems.Push(purchase);
    }
}
