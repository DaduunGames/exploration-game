using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool IsGrounded;

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.layer != 7)
        {
            IsGrounded = true;
            
        }
        else
        {
            IsGrounded = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        IsGrounded = false;
        
    }
}
