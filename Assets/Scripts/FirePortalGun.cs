using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePortalGun : MonoBehaviour
{
    [SerializeField] GameObject portal1;
    [SerializeField] GameObject portal2;
    [SerializeField] Camera cameraController;
    int layerMask = 1 << 9;
    GameObject portal1Instance;
    GameObject portal2Instance;

    RaycastHit objectHit;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ShootPortal1();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ShootPortal2();
        }
    }
    void ShootPortal1()
    {
        Vector3 rayDirection = cameraController.transform.forward;
        if(Physics.Raycast(cameraController.transform.position, rayDirection, out objectHit, Mathf.Infinity, layerMask))
        {
            if (portal1Instance != null)
            {
                Destroy(portal1Instance);
            }
            
            portal1.transform.position = objectHit.point;
            
            portal1Instance = Instantiate(portal1, portal1.transform.position, objectHit.transform.rotation);
        }
    }
    void ShootPortal2()
    {
        Vector3 rayDirection = cameraController.transform.forward;
        if(Physics.Raycast(cameraController.transform.position, rayDirection, out objectHit, Mathf.Infinity, layerMask))
        {
            if(portal2Instance != null)
            {
                Destroy(portal2Instance);
            }

            portal2.transform.position = objectHit.point;
            portal2Instance = Instantiate(portal2, portal2.transform.position, objectHit.transform.rotation);
        }
    }
}
