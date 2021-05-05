using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2Transport : MonoBehaviour
{
    [SerializeField] Transform portal1;
    [SerializeField] CharacterController FPP;


    void OnTriggerEnter(Collider other)
    {
        TeleportCooldown teleportCooldown = other.gameObject.GetComponent<TeleportCooldown>();
        if (teleportCooldown.OnCooldown() == false)
        {
            StartCoroutine(TeleportSequence(teleportCooldown));
        }

    }
    IEnumerator TeleportSequence(TeleportCooldown teleportCooldown)
    {
        teleportCooldown.changeCooldown();
        
        FPP.enabled = false;
        FPP.transform.position = new Vector3(portal1.position.x, portal1.position.y, portal1.position.z);
        FPP.enabled = true;
        yield return new WaitForSeconds(0.5f);
        teleportCooldown.changeCooldown();
    }
}
