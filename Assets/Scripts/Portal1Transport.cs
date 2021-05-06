using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1Transport : MonoBehaviour
{
    Transform portal2;
    Transform portal1;
    CharacterController FPP;
    [SerializeField] AudioSource teleport;
    
    
    
    void OnTriggerEnter(Collider other)
    {
        FPP = other.gameObject.GetComponent<CharacterController>();
        TeleportCooldown teleportCooldown = other.gameObject.GetComponent<TeleportCooldown>();
        if(teleportCooldown.OnCooldown() == false)
        {
            StartCoroutine(TeleportSequence(teleportCooldown));
        }
        
       
    }
    IEnumerator TeleportSequence(TeleportCooldown teleportCooldown)
    {
        portal2 = GameObject.FindGameObjectWithTag("Portal2").GetComponent<Transform>();
        portal1 = GameObject.FindGameObjectWithTag("Portal1").GetComponent<Transform>();
        
        teleportCooldown.changeCooldown();
        
        FPP.enabled = false;
        FPP.transform.position = new Vector3(portal2.position.x, portal2.position.y, portal2.position.z);
        teleport.Play();
        if(portal1.eulerAngles.y == portal2.eulerAngles.y)
        {
            Debug.Log(portal1.localEulerAngles.y+ " "+ portal2.localEulerAngles.y);
            FPP.transform.Rotate(0, 180, 0);
        }
        
        FPP.enabled = true;
        yield return new WaitForSeconds(0.5f);
        teleportCooldown.changeCooldown();
    }
}
