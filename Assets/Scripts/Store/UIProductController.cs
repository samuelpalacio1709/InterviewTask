using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProductController : MonoBehaviour
{
    [SerializeField] Image productImage;
    [SerializeField] GameObject selectedBorderImage;

    public void ShowBorder(bool state)
    {
        selectedBorderImage.gameObject.SetActive(state);
    }
    public void UpdateUI(Sprite sprite)
    {
       productImage.sprite = sprite;  
    }
}
