using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private enum OpeningDirection { x, y, z };
    [SerializeField] private OpeningDirection direction = OpeningDirection.y;

    [SerializeField] private float openDistance = 3.0f;
    [SerializeField] private float openingSpeed = 2.0f;

    [SerializeField] private bool locked = false;

    [SerializeField] private bool isOpen = false;

    [SerializeField] private Vector3 closedPosition;
    
    void Update()
    {
        if (direction == OpeningDirection.x)
        {
            transform.localPosition = new Vector3(Mathf.Lerp(transform.localPosition.x, closedPosition.x + (isOpen ? openDistance : 0), Time.deltaTime * openingSpeed), transform.localPosition.y, transform.localPosition.z);
        }
        else if (direction == OpeningDirection.y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, closedPosition.y + (isOpen ? openDistance : 0), Time.deltaTime * openingSpeed), transform.localPosition.z);
        }
        else if (direction == OpeningDirection.z)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.Lerp(transform.localPosition.z, closedPosition.z + (isOpen ? openDistance : 0), Time.deltaTime * openingSpeed));
        }
    }

    public void Interact()
    {
        if (!locked)
        {
            isOpen = !isOpen;
        }
    }

    public void ForceInteract()
    {
        isOpen = !isOpen;
    }
}
