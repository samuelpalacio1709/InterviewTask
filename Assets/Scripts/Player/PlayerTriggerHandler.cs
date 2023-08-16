using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerHandler : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable;
        collision.gameObject.TryGetComponent(out interactable);
        if (interactable != null)
        {
            interactable.ShowInteraction();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable;
        collision.gameObject.TryGetComponent(out interactable);
        if (interactable != null)
        {
            interactable.HideInteraction();
        }
    }


}
