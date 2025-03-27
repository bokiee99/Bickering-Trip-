using System.Collections;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public GameObject cloud;
    public Vector2 loweredPositionOffset = new Vector2(0, -2); // 구름이 이동할 위치의 오프셋
    private Vector2 originalPosition;
    private int playercnt;

    private Coroutine moveCoroutine;

    void Start()
    {
        originalPosition = cloud.transform.position;
    }

    void Update()
    {
        // Update 메서드에서는 아무 작업도 하지 않습니다.
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playercnt++;
            UpdateCloudPosition();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playercnt--;
            UpdateCloudPosition();
        }
    }

    private void UpdateCloudPosition()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        if (playercnt >= 2)
        {
            // 두 명의 플레이어가 올라갔을 때 구름을 아래로 이동
            moveCoroutine = StartCoroutine(MoveCloud(cloud.transform.position, originalPosition + loweredPositionOffset));
        }
        else
        {
            // 한 명 이하의 플레이어가 남았을 때 구름을 원래 위치로 이동
            moveCoroutine = StartCoroutine(MoveCloud(cloud.transform.position, originalPosition));
        }
    }

    private IEnumerator MoveCloud(Vector2 start, Vector2 end)
    {
        float elapsedTime = 0;
        float duration = 1f; // 구름이 이동하는 데 걸리는 시간

        while (elapsedTime < duration)
        {
            cloud.transform.position = Vector2.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cloud.transform.position = end;
    }
}