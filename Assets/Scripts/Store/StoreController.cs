using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

[RequireComponent(typeof(UIStoreController))]
public class StoreController : MonoBehaviour
{
    [SerializeField] private UIStoreController UIStore;
    [SerializeField] private ProductSO[] availableProducts;
    [SerializeField] private GameObject[] options;
    private WearablesManager wearablesManager => WearablesManager.Instance;
    private PurchaseManager purchaseManager => PurchaseManager.Instance;
    private GameManager gameManager => GameManager.Instance;

    private List<IProduct> products = new List<IProduct>();
    private List<IStoreOption> storeOptions = new List<IStoreOption>();
    private IProduct selectedProduct;
    private IStoreOption selectedOption;
    public Action OnStoreClosed;
    public void Start()
    {
        CreateProducts();
        SubscribeToStoreOptionEvents();
        UIStore.BuyButton.onClick.AddListener(BuyProduct);
        UIStore.closeButton.onClick.AddListener(CloseStore);
    }
    public void BuyProduct()
    {
        if (selectedProduct.ProductInfo.productPrice > gameManager.TotalCoins)
        {
            UIStore.ShowRejectPurchaseText(true);
            return;
        }
        gameManager.DecreaseCoins(selectedProduct.ProductInfo.productPrice);
        purchaseManager.CreatePurchase(selectedProduct);
        UIStore.LaunchPromptToWearNewProduct(selectedProduct);
        wearablesManager.CreateWearable(selectedProduct.ProductInfo.iD);
    }
    public void SelectProduct(ProductSO product)
    {
        UIStore.SetPriceText(product.productPrice);
    }

    public void OpenStore()
    {
        wearablesManager.MatchClothes();

        if (selectedProduct != null) 
            selectedProduct.Deselect();


        if (products.Count > 0)
            UIStore.Show();

        UpgradeProductsSection();
    }

    public void CloseStore()
    {
        OnStoreClosed?.Invoke();
        UIStore.ShowRejectPurchaseText(false);
    }

    public void CreateProducts()
    {
        foreach (var productInfo in availableProducts)
        {
            GameObject newProduct = UIStore.CreateNewProduct();
            IProduct productCreated;
            newProduct.TryGetComponent<IProduct>(out productCreated);
            if (newProduct == null) continue;

            AddProductInfo(productCreated, productInfo);
            SubscribeToProductEvents(productCreated);
            products.Add(productCreated);
        }
    }

    private void  AddProductInfo(IProduct productCreated, ProductSO productInfo)
    {
        productCreated.FillInfo(productInfo);
    }

    private void SubscribeToProductEvents(IProduct product)
    {
        product.OnSelected += SelectProduct;
    }
    private void SubscribeToStoreOptionEvents()
    {
        if (options.Length <= 0) return;
        foreach (var item in options)
        {
            IStoreOption option;
            item.TryGetComponent<IStoreOption>(out option);
            if (option != null)
            {
                option.OnSelected += SelectOption;
                storeOptions.Add(option);
            }
        }
        SelectOption(storeOptions[0]);
    }

    private void SelectProduct(IProduct product)
    {
        product.TryProduct();
        if (product == selectedProduct) return;

        if(selectedProduct != null)
        {
            selectedProduct.Deselect(); //Deselect the actual selected product
        }
        selectedProduct = product;
        UIStore.SelectProductUI(product);
    }

    private void SelectOption(IStoreOption option)
    {
        if (selectedOption != null)
        {
            selectedOption.Deselect();
        }
        selectedOption = option;
        selectedOption.Select();
        UpgradeProductsSection();
    }

    private void UpgradeProductsSection()
    {
        foreach (var item in products)
        {
            if (selectedOption.Type == item.ProductInfo.productType
                   && !wearablesManager.wearablesDictionary.ContainsKey(item.ProductInfo.iD))
            {
                item.canvasObject.SetActive(true);
            }
            else
            {
                item.canvasObject.SetActive(false);

            }

        }
    }

}


