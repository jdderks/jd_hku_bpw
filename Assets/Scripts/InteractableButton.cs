using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class InteractableButton : MonoBehaviour, IInteractable
{
    [SerializeField] UnityEvent Reaction = default;
    [SerializeField] private string flavorText;

    public string FlavorText { get => flavorText; set => flavorText = value; }

    public void Interact()
    {
        Reaction.Invoke();
    }
}
