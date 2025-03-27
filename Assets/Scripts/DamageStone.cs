using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageStone : MonoBehaviour
{
    public float damage = 10;
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
        StoneHealth hp = other.GetComponent<StoneHealth>();
        if (hp!=null)
        {
            hp.TakeDamage(damage);
        }
    }
}
