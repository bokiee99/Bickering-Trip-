using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerToFollowPrefab; // �� ��ȯ �� ���� �÷��̾��� ������
    public GameObject playerToFollow;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded; // ���� �ε�� ������ �̺�Ʈ�� �����ϱ� ���� ���
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ���ο� ���� �ε�� ������ ���ο� ī�޶� ����
        GameObject newCamera = new GameObject("MainCamera");
        CinemachineVirtualCamera vCam = newCamera.AddComponent<CinemachineVirtualCamera>();

        // ���ο� ������ ���� �÷��̾ ã�Ƽ� ī�޶��� follow ������� ����
        if (playerToFollow != null)
        {
            vCam.Follow = playerToFollow.transform;
        }
        else
        {
            // ���ο� ������ �÷��̾ ã�� �� ���� ���, ���� ������ ������ �÷��̾��� �������� ����Ͽ� ���� ����
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
