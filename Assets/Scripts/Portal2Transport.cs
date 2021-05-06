using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2Transport : MonoBehaviour
{
    Transform portal1;
    Transform portal2;
    CharacterController FPP;
    [SerializeField] AudioSource teleport;


    void OnTriggerEnter(Collider other)
    {
        FPP = other.gameObject.GetComponent<CharacterController>();
        TeleportCooldown teleportCooldown = other.gameObject.GetComponent<TeleportCooldown>();
        if (teleportCooldown.OnCooldown() == false)
        {
            StartCoroutine(TeleportSequence(teleportCooldown));
        }

    }
    IEnumerator TeleportSequence(TeleportCooldown teleportCooldown)
    {
        portal1 = GameObject.FindGameObjectWithTag("Portal1").GetComponent<Transform>();
        portal2 = GameObject.FindGameObjectWithTag("Portal2").GetComponent<Transform>();
        
        
        teleportCooldown.changeCooldown();
        
        FPP.enabled = false;
        FPP.transform.position = new Vector3(portal1.position.x, portal1.position.y, portal1.position.z);
        teleport.Play();
        if(portal1.eulerAngles.y == portal2.eulerAngles.y)
        {
            FPP.transform.Rotate(0, 180, 0);
        }
        
        FPP.enabled = true;
        yield return new WaitForSeconds(0.5f);
        teleportCooldown.changeCooldown();
    }
}
