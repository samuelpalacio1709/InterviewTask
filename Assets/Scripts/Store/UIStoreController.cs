using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIStoreController : MonoBehaviour
{
    [SerializeField] public Button closeButton;
    [SerializeField] private TMP_Text priceText;
    [SerializeField] private TMP_Text productNameText;
    [SerializeField] private Image productImage;
    [SerializeField] private GameObject productPrefab;
    [SerializeField] private Transform productShelf;
    [SerializeField] private Button buyButton;
    [SerializeField] private string purchasedItemText;
    [SerializeField] private GameObject storeCanvasObject;
    public Button BuyButton { get => buyButton; set => buyButton = value; }
    private GlobalUIManager globalUIManager => GlobalUIManager.Instance;

    private void OnEnable()
    {
        buyButton.interactable = false;
        closeButton.onClick.AddListener(CloseStoreUI);
    }
    private void OnDisable()
    {
        closeButton.onClick.RemoveListener(CloseStoreUI);
    }
    public void SelectProductUI(IProduct product)
    {
        productImage.sprite = product.ProductInfo.productIcon;
        productNameText.text = product.ProductInfo.productName;
        buyButton.interactable = true;
        SetPriceText(product.ProductInfo.productPrice);
    }

    public void SetPriceText(float price)
    {
        priceText.text = price.ToString();
    }
    public GameObject CreateNewProduct()
    {
        GameObject newProduct = Instantiate(productPrefab, productShelf);
        return newProduct;
    }

    //Show propmt to ask the user if want to wear the purchased item
    public void LaunchPromptToWearNewProduct(IProduct product)
    {
        string message = purchasedItemText.Replace("product", product.ProductInfo.productName);
        storeCanvasObject.SetActive(false);
        globalUIManager.ShowPrompt(message, product.ProductInfo.productIcon);
    }

    public void CloseStoreUI()
    {
        storeCanvasObject.SetActive(false);
    }

    public void Show()
    {
        storeCanvasObject.gameObject.SetActive(true);   
    }
}
