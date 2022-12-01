using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private interactionPromptUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numFound;

    private IInteractable _interactable;

    public int destroyedCrystals = 0;
    private bool forceFieldDown = false;
    [SerializeField] public GameObject forcefield;

    private void Update()
    {
        // finds all the interactable components found in area and adds them to the array
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);

        if(_numFound > 0)
        {
            _interactable = _colliders[0].GetComponent<IInteractable>();

            if(_interactable != null)
            {
                if(!_interactionPromptUI.IsDisplayed)
                {
                    _interactionPromptUI.SetUp(_interactable.InteractionPrompt);
                }

                if(Keyboard.current.eKey.wasPressedThisFrame)
                {
                    _interactable.Interact(this);
                }
            }
        }
        else
        {
            if(_interactable != null) _interactable = null;
            if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
        }

        if(destroyedCrystals >= 4 && !forceFieldDown)
        {
            forceFieldDown = true;
            forcefield.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
