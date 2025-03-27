using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BGMPlay : MonoBehaviour
{
    private int playercnt;
    public AudioSource BGMplay;
    public AudioSource BGMstop;
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
            playercnt++;
        }

        if (playercnt == 2)
        {
            BGMstop.Stop();
            BGMplay.Play();
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
