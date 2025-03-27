using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public Transform exit1;
    public Transform exit2;
    public GameObject player1;
    public GameObject player2;  

    private int playercnt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playercnt == 2)
        {
            AudioManager.instance.PlaySFX(3);
            player1.transform.position = exit1.transform.position;
            player2.transform.position = exit2.transform.position;      
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playercnt++;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playercnt--;

        }
    }
}
