using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityEnd : MonoBehaviour
{
    void Start()
    {
        GravityController.instance.gcheck = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.SetGravity(5);
            }
        }
    }
}
