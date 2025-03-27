using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public static GravityController instance;
    public float Gravityforce = 0.05f;
    public bool gcheck = false;
    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                gcheck = true;
                playerController.SetGravity(Gravityforce);
            }
        }
    }

}
