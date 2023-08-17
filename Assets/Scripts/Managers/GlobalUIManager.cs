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



    [Header("Main Menu")]
    [SerializeField] Button startButton;
    [SerializeField] Button closeInstructionsButton;
    [SerializeField] Button exitApp;
    [SerializeField] GameObject mainMenuObjectCanvas;
    [SerializeField] GameObject instructionObjectCanvas;

    private PromptType actualPromptType = PromptType.Wear;

    public static Action onEndInstructions;
    public enum PromptType
    {
        Wear
    }

    private void OnEnable()
    {
        confirmPromptButton.onClick.AddListener(AcceptPrompt);
        cancelPromptButton.onClick.AddListener(CancelPrompt);
        GameManager.onCoinsChanged += UpdateCoinsUI;
        startButton.onClick.AddListener(HandleStartUI);
        closeInstructionsButton.onClick.AddListener(HandleEndInstructionsUI);
        exitApp.onClick.AddListener(HandleExit);

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

    private void HandleStartUI()
    {
        mainMenuObjectCanvas.SetActive(false);
    }

    private void HandleEndInstructionsUI()
    {
        onEndInstructions?.Invoke();
        instructionObjectCanvas.gameObject.SetActive(false);
    }
    private void HandleExit()
    {
        Application.Quit();
    }
}