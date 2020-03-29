using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class InteractableButton : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent Reaction = default;

    public void Interact()
    {
        Reaction.Invoke();
    }
}
