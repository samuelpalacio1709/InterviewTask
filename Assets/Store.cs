using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour, IInteractable
{
    public void ShowInteraction()
    {
        Debug.Log("Show");
    }
    public void HideInteraction()
    {
        Debug.Log("Hide");
    }
}
