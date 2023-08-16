using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClothsController : MonoBehaviour
{
    private WearablesManager wearablesManager => WearablesManager.Instance;
    private PurchaseManager purchaseManager => PurchaseManager.Instance;


    private void OnEnable()
    {
        PromptHandler.OnWearItemPrompt += WearItem;
    }
    private void OnDisable()
    {
        PromptHandler.OnWearItemPrompt -= WearItem;
    }

    public void WearItem()
    {
        wearablesManager.UseWearable(purchaseManager.LastPurchase.productInfo.iD);
    }
}
