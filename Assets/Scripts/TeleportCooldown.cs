using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCooldown : MonoBehaviour
{
    bool _onCooldown = false;
    
    
    public bool OnCooldown()
    {
        Debug.Log(_onCooldown);
        if(_onCooldown == false)
        {
           //Debug.Log("not on cooldown");
            return false;

        }
        else
        {
            //Debug.Log("on cooldown");
            return true;
        }
    }
    public void changeCooldown()
    {
        if(_onCooldown == false)
        {
            //Debug.Log(_onCooldown);
            _onCooldown = true;
        }
        else
        {
            _onCooldown = false;
        }
    }
}
