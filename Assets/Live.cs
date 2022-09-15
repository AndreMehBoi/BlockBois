using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Live : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Lava")
        {
            this.GetComponent<Movement>().respawn();
        }    
    }
}
