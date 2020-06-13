using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerCameraBehaviour : MonoBehaviour
{
    [SerializeField] private string mouseXInputName = default; //Input name for inputmanager on X
    [SerializeField] private string mouseYInputName = default; //Input name for inputmanager on Y
    [SerializeField] private string interactButtonName = default; //Input name for inputmanager to interact

    [SerializeField] private Image reticle;

    [SerializeField] private TextMeshProUGUI grabText;

    [SerializeField] private Transform playerBody = default; //The transform of the player for movement

    private float xAxisClamp = default; //Tracker of the clamping of the camera

    [SerializeField] private float mouseSensitivity = default; //The sensitivity of the mouse
    [SerializeField] private float interactDistance = 2f; //The distance the player can interact with interactables

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
        InteractInput();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    private void InteractInput()
    {

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.transform.tag == "Interactable")
            {
                grabText.text = hit.transform.GetComponent<InteractableButton>().FlavorText;
                reticle.color = Color.white;
                if (Input.GetButtonDown(interactButtonName))
                {
                    hit.transform.GetComponent<IInteractable>().Interact();
                }
            }
            else
            {
                grabText.text = "";
                reticle.color = Color.black;
            }
        }
        else
        {
            reticle.color = Color.black;
        }
    }



}
