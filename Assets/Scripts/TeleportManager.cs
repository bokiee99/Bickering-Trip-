using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public Transform plainExit1, plainExit2;
    public Transform forestExit1, forestExit2;
    public Transform rockExit1, rockExit2;
    public Transform snowExit1, snowExit2;
    public Transform fallExit1, fallExit2;
    public Transform sea1Exit1, sea1Exit2;
    public Transform sea2Exit1, sea2Exit2;

    public GameObject player1;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player1.transform.position = plainExit1.transform.position;
            player2.transform.position = plainExit2.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player1.transform.position = forestExit1.transform.position;
            player2.transform.position = forestExit2.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player1.transform.position = rockExit1.transform.position;
            player2.transform.position = rockExit2.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            player1.transform.position = snowExit1.transform.position;
            player2.transform.position = snowExit2.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            player1.transform.position = fallExit1.transform.position;
            player2.transform.position = fallExit2.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            player1.transform.position = sea1Exit1.transform.position;
            player2.transform.position = sea1Exit2.transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            player1.transform.position = sea2Exit1.transform.position;
            player2.transform.position = sea2Exit2.transform.position;
        }
    }
}
