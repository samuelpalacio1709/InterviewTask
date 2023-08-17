using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptHandler : MonoBehaviour
{
    public static Action OnWearItemPrompt;
    public static Action OnWearItemCanceled;

    public void HandlePromptAccepted(GlobalUIManager.PromptType promptType)
    {
       switch(promptType)
        {
            case GlobalUIManager.PromptType.Wear:
                OnWearItemPrompt?.Invoke();
                break;
        }
    }

    public void HandlePromptRejected()
    {
        OnWearItemCanceled?.Invoke();
    }
}
