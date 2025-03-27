using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool isHealth, isSpeed;

    public float powerupLength, powerUpAmount;
    public float powerUpAmount2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (isHealth)
            {
                other.GetComponent<PlayerHealthController>().FillHealth();

                AudioManager.instance.PlaySFX(0);
            }

            if (isSpeed)
            {
                PlayerController thePlayer = other.GetComponent<PlayerController>();
                thePlayer.speedStore = thePlayer.moveSpeed;
                thePlayer.climbStore = thePlayer.climbSpeed;
                thePlayer.moveSpeed = powerUpAmount;
                thePlayer.climbSpeed = powerUpAmount2;
                thePlayer.powerUpCounter = powerupLength;

                AudioManager.instance.PlaySFX(4);
            }

            Destroy(gameObject);
        }
    }
}
