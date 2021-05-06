using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraMove : MonoBehaviour
{
    Transform player;
    [SerializeField] Camera portal2Camera;
    [SerializeField] GameObject portal1;
    float playerXDistFromPortal;
    float playerZDistFromPortal;

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerXDistFromPortal = Mathf.Abs(player.position.x - portal1.transform.position.x);
        playerZDistFromPortal = Mathf.Abs(player.position.z - portal1.transform.position.z);
        Debug.Log(playerXDistFromPortal + " " + playerZDistFromPortal);
    }
}
