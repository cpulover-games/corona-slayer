using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomWeapon : MonoBehaviour
{
    private Controller controller;
    private Camera mainCamera;
    private Camera weaponCamera;
    private bool isZoomed = false;
    [SerializeField] private float zoomInMainCamera = 40f;
    [SerializeField] private float zoomOutMainCamera = 60f;
    [SerializeField] private float zoomInWeaponCamera = 20f;
    [SerializeField] private float zoomOutWeaponCamera = 40f;
    [SerializeField] float zoomOutMouseSensitivity = 2.4f;
    [SerializeField] float zoomInMouseSensitivity = 8f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessZoomInput();
    }

    public void SetMainCamera(Camera camera)
    {
        mainCamera = camera;
    }

    public void SetWeaponCamera(Camera camera)
    {
        weaponCamera = camera;
    }

    public void SetController(Controller theController)
    {
        controller = theController;
    }

    private void ProcessZoomInput()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isZoomed = !isZoomed;
            if (isZoomed)
            {
                mainCamera.fieldOfView = zoomInMainCamera;
                weaponCamera.fieldOfView = zoomInWeaponCamera;
                controller.mouseSensitivity = zoomInMouseSensitivity;
            }
            else
            {
                mainCamera.fieldOfView = zoomOutMainCamera;
                weaponCamera.fieldOfView = zoomOutWeaponCamera;
                controller.mouseSensitivity = zoomOutMouseSensitivity;
            }
        }
    }
}
