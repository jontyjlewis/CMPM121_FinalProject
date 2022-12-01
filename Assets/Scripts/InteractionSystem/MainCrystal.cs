using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCrystal : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject _crystal;
    [SerializeField] private Material day;
    [SerializeField] private GameObject flashlight;
    [SerializeField] private Light _directionalLight;

    public string InteractionPrompt => _prompt; // equivalent to InteractionPrompt { get => _prompt; }

    public bool Interact(Interactor interactor)
    {
        Object.Destroy(_crystal);
        RenderSettings.skybox = day;
        RenderSettings.fog = false;
        flashlight.SetActive(false);
        _directionalLight.color = Color.white;
        Debug.Log("Destroyed the Eternal Night!");
        return true;
    }
}
