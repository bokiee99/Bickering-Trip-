using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public float targetSize = 4f;
    public float duration = 2f;
    private float originalSize;
    private bool isTriggered = false;

    public GameObject WIN, LOSE;
    public GameObject Screen;
    // Start is called before the first frame update
    void Start()
    {
        originalSize = virtualCamera.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (EndingCheck.instnace.ending == true)
        {
            if (PlayerController.instance.hiddenCnt >= 2)
            {
                PlayerController.instance.player1_good_emotion.SetActive(true);
                PlayerController.instance.player2_good_emotion.SetActive(true);
                if (!isTriggered)
                {
                    StartCoroutine(ChangeCameraSize());
                    isTriggered = true;
                }
            }
            else
            {
                PlayerController.instance.player1_bad_emotion.SetActive(true);
                PlayerController.instance.player2_bad_emotion.SetActive(true);
                if (!isTriggered)
                {
                    StartCoroutine(ChangeCameraSize());
                    isTriggered = true;
                }
            }
        }
    }

    IEnumerator ChangeCameraSize()
    {
        virtualCamera.m_Lens.OrthographicSize = targetSize;
        yield return new WaitForSeconds(duration);
        virtualCamera.m_Lens.OrthographicSize = originalSize;
        if (PlayerController.instance.hiddenCnt >= 2)
        {
            Screen.SetActive(true);
            WIN.SetActive(true);
        }
        else
        {
            Screen.SetActive(true);
            LOSE.SetActive(true);
        }
        isTriggered = false;  // 재사용을 원하면 이 줄을 활성화
    }
}
