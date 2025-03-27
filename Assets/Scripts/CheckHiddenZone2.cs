using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//여캐릭터 호감도 상승존
public class CheckHiddenZone2 : MonoBehaviour
{
    public static CheckHiddenZone2 instance;
    private int playercnt;
    public bool checkzone2;
 
    public GameObject portal;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (checkzone2 == true)
        {
            portal.SetActive(true);
        }
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
 
            playercnt++;

        }

        if (playercnt == 2)
        {
            checkzone2 = true;
            PlayerController.instance.player1_good_emotion.SetActive(true);
            PlayerController.instance.hiddenCnt++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playercnt--;

        }

        if(playercnt <= 1)
        {
            checkzone2 = false;
            PlayerController.instance.player1_good_emotion.SetActive(false);
        }
    }
}
