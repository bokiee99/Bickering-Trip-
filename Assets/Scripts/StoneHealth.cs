using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class StoneHealth : MonoBehaviour
{
    public float health = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            AudioManager.instance.PlaySFX(5);
            Destroy(gameObject);
        }
    }
}
