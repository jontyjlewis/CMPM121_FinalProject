using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class interactionPromptUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _promptText;
    [SerializeField] private GameObject _uiPanel;

    private void Start()
    {
        _uiPanel.SetActive(false);
    }

    public bool IsDisplayed = false;
    public void SetUp(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        _uiPanel.SetActive(false);
        IsDisplayed = false;
    }
}
