using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCheck : MonoBehaviour
{
    public bool ending = false;
    public static EndingCheck instnace;
    private int playercnt;
    // Start is called before the first frame update
    private void Awake()
    {
        instnace = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playercnt == 2)
        {
            ending = true;
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
