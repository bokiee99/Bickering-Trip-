using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// 히든 위치 도달 시 확대 기능 (점검 필요, 캐릭터가 아닌 다른 곳을 봄)
public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera main;
    private float startSize;
    private bool isZooming = false;


    void Start()
    {
        if (main == null)
        {
            main = GetComponent<CinemachineVirtualCamera>();
        }
        startSize = main.m_Lens.OrthographicSize;
    }

    void Update()
    {
        if (CheckHiddenZone.instance.checkzone && !isZooming)
        {
            StartCoroutine(CameraZoom());
        }

        if (CheckHiddenZone2.instance.checkzone2 && !isZooming)
        {
            StartCoroutine(CameraZoom());
        }
    }

    IEnumerator CameraZoom()
    {
        isZooming = true;
        main.m_Lens.OrthographicSize = startSize / 2;
        yield return new WaitForSeconds(2f);
        main.m_Lens.OrthographicSize = startSize;
        isZooming = false;
    }
}