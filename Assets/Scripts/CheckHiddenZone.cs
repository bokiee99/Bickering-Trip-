using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//여캐릭터 호감도 상승존
public class CheckHiddenZone : MonoBehaviour
{
    public static CheckHiddenZone instance;
    private int playercnt;
    public bool checkzone;
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
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playercnt++;
        }

        if (playercnt == 2)
        {
            checkzone = true;
            PlayerController.instance.player2_good_emotion.SetActive(true);
            PlayerController.instance.hiddenCnt++;
            portal.SetActive(true);
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
            checkzone = false;
            PlayerController.instance.player2_good_emotion.SetActive(false);
        }
    }
}
