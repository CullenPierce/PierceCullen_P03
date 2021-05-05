using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1Transport : MonoBehaviour
{
    [SerializeField] Transform portal2;
    [SerializeField] CharacterController FPP;
    
    
    
    void OnTriggerEnter(Collider other)
    {
        TeleportCooldown teleportCooldown = other.gameObject.GetComponent<TeleportCooldown>();
        if(teleportCooldown.OnCooldown() == false)
        {
            StartCoroutine(TeleportSequence(teleportCooldown));
        }
        
       
    }
    IEnumerator TeleportSequence(TeleportCooldown teleportCooldown)
    {
        teleportCooldown.changeCooldown();
        
        FPP.enabled = false;
        FPP.transform.position = new Vector3(portal2.position.x, portal2.position.y, portal2.position.z);
        FPP.enabled = true;
        yield return new WaitForSeconds(0.5f);
        teleportCooldown.changeCooldown();
    }
}
