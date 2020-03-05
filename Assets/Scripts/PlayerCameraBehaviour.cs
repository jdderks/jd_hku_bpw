using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraBehaviour : MonoBehaviour
{
    [SerializeField] private string mouseXInputName = default; //Input name for inputmanager on X
    [SerializeField] private string mouseYInputName = default; //Input name for inputmanager on Y
    [SerializeField] private string shootInputName = default; //Input name for inputmanager to shoot
    [SerializeField] private string interactButtonName = default; //Input name for inputmanager to interact
    

    [SerializeField] private GunBehaviour gun;

    [SerializeField] private Transform playerBody = default; //The transform of the player for movement

    private float xAxisClamp = default; //Tracker of the clamping of the camera

    [SerializeField] private float mouseSensitivity = default; //The sensitivity of the mouse


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
        //ShootInput();
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
        if (Input.GetButtonDown(interactButtonName))
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);

            float interactDistance = 2f;
            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.transform.tag == "Interactable")
                {
                    hit.transform.GetComponent<IInteractable>().Interact();
                }
                if (hit.transform.tag == "Item")
                {
                    hit.transform.GetComponent<Item>().Grab();

                }
            }
        }
    }

    private void ShootInput()
    {
        if (Input.GetButtonDown(shootInputName))
        {
            gun.Shoot();
        }
    }

}
