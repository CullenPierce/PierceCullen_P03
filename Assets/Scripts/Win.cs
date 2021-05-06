using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [SerializeField] Text youWin;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource win;

    private void Start()
    {
        youWin.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        youWin.enabled = true;
        other.enabled = false;
        win.Play();
    }
}
