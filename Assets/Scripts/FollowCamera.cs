using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerToFollowPrefab; // 씬 전환 시 따라갈 플레이어의 프리팹
    public GameObject playerToFollow;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬이 로드될 때마다 이벤트를 수신하기 위해 등록
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 새로운 씬이 로드될 때마다 새로운 카메라를 생성
        GameObject newCamera = new GameObject("MainCamera");
        CinemachineVirtualCamera vCam = newCamera.AddComponent<CinemachineVirtualCamera>();

        // 새로운 씬에서 기존 플레이어를 찾아서 카메라의 follow 대상으로 설정
        if (playerToFollow != null)
        {
            vCam.Follow = playerToFollow.transform;
        }
        else
        {
            // 새로운 씬에서 플레이어를 찾을 수 없는 경우, 이전 씬에서 생성한 플레이어의 프리팹을 사용하여 새로 생성
            if (playerToFollowPrefab != null)
            {
                playerToFollow = Instantiate(playerToFollowPrefab);
                vCam.Follow = playerToFollow.transform;
            }
            else
            {
                Debug.LogError("Player prefab is not assigned.");
            }
        }
    }
}
