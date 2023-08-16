using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class GlobalUIManager : Singleton<GlobalUIManager>
{
    [Header("Prompt Message")]

    [SerializeField] GameObject promptCanvasObject;
    [SerializeField] TMP_Text promptText;
    [SerializeField] Image promptImage;
    [SerializeField] Button confirmPromptButton;
    [SerializeField] Button cancelPromptButton;
    private Action OnPromptAcepted;


    private void OnEnable()
    {
        confirmPromptButton.onClick.AddListener(AcceptPrompt);
        cancelPromptButton.onClick.AddListener(CancelPrompt);
    }

    private void OnDisable()
    {
        confirmPromptButton.onClick.RemoveAllListeners();
        cancelPromptButton.onClick.RemoveAllListeners();
    }


    public Action ShowPrompt(string text, Sprite icon)
    {
        promptCanvasObject.gameObject.SetActive(true);
        promptText.text = text;
        promptImage.sprite = icon;
        OnPromptAcepted =null;
        return OnPromptAcepted;
    }

    public void AcceptPrompt()
    {
        OnPromptAcepted?.Invoke();
        OnPromptAcepted = null;
    }
    public void CancelPrompt()
    {
        OnPromptAcepted = null;
    }
}
