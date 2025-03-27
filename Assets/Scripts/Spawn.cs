using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̻�� �ڵ� �ٸ� �� �Ѿ �� (���� ����Ʈ��)
public class Spawn : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {

        foreach (PlayerController player in GameManager.instance.players)
        {
            int randomPoint = Random.Range(0, spawnPoints.Count);
            player.transform.position = spawnPoints[randomPoint].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
