using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCooldown : MonoBehaviour
{
    bool _onCooldown = false;
    
    
    public bool OnCooldown()
    {
        
        if(_onCooldown == false)
        {
            return false;

        }
        else
        {
            return true;
        }
    }
    public void changeCooldown()
    {
        if(_onCooldown == false)
        {
            _onCooldown = true;
        }
        else
        {
            _onCooldown = false;
        }
    }
}
