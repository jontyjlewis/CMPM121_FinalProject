using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] private GameObject _crystal;
    
    public string InteractionPrompt => _prompt; // equivalent to InteractionPrompt { get => _prompt; }

    public bool Interact(Interactor interactor)
    {
        Object.Destroy(_crystal);
        interactor.destroyedCrystals++;
        Debug.Log("Destroyed Crystal!");
        return true;
    }
}
