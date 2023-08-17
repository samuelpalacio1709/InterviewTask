using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class GlobalUIManager : Singleton<GlobalUIManager>
{
    [Header("Prompt Message")]

    [SerializeField] GameObject promptCanvasObject;
    [SerializeField] TMP_Text promptText;
    [SerializeField] Image promptImage;
    [SerializeField] Button confirmPromptButton;
    [SerializeField] Button cancelPromptButton;
    [SerializeField] PromptHandler promptHandler;

    [Header("Sticky Message")]

    [SerializeField] GameObject stickyMessageCanvasObject;
    [SerializeField] TMP_Text stickyMessage;


    [Header("Coins")]
    [SerializeField] TMP_Text coinsText;


    [Header("Inventary")]
    [SerializeField] Button sellButton;
    [SerializeField] Button equipButton;
    [SerializeField] Button removeButton;

    private PromptType actualPromptType = PromptType.Wear;


    public enum PromptType
    {
        Wear
    }

    private void OnEnable()
    {
        confirmPromptButton.onClick.AddListener(AcceptPrompt);
        cancelPromptButton.onClick.AddListener(CancelPrompt);
        GameManager.onCoinsChanged += UpdateCoinsUI;
    }

    private void OnDisable()
    {
        confirmPromptButton.onClick.RemoveAllListeners();
        cancelPromptButton.onClick.RemoveAllListeners();
        GameManager.onCoinsChanged -= UpdateCoinsUI;
    }


    public void ShowPrompt(string text, Sprite icon, PromptType promptType = PromptType.Wear)
    {
        promptCanvasObject.gameObject.SetActive(true);
        promptText.text = text;
        promptImage.sprite = icon;
        actualPromptType = promptType;
    }

    public void AcceptPrompt()
    {
        promptHandler.HandlePromptAccepted(actualPromptType);
        promptCanvasObject.gameObject.SetActive(false);
    }
    public void CancelPrompt()
    {
        promptHandler.HandlePromptRejected();
        promptCanvasObject.gameObject.SetActive(false);
    }

    public void ShowStickyMessage(string message)
    {
        stickyMessage.text = message;
        stickyMessageCanvasObject.gameObject.SetActive(true);
    }
    public void HideStickyMessage()
    {
        stickyMessageCanvasObject.gameObject.SetActive(false);
    }

    public void UpdateCoinsUI(float coins)
    {
        coinsText.text = coins.ToString();
    }

}