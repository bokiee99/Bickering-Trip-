using System.Collections;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public GameObject cloud;
    public Vector2 loweredPositionOffset = new Vector2(0, -2); // ������ �̵��� ��ġ�� ������
    private Vector2 originalPosition;
    private int playercnt;

    private Coroutine moveCoroutine;

    void Start()
    {
        originalPosition = cloud.transform.position;
    }

    void Update()
    {
        // Update �޼��忡���� �ƹ� �۾��� ���� �ʽ��ϴ�.
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
            // �� ���� �÷��̾ �ö��� �� ������ �Ʒ��� �̵�
            moveCoroutine = StartCoroutine(MoveCloud(cloud.transform.position, originalPosition + loweredPositionOffset));
        }
        else
        {
            // �� �� ������ �÷��̾ ������ �� ������ ���� ��ġ�� �̵�
            moveCoroutine = StartCoroutine(MoveCloud(cloud.transform.position, originalPosition));
        }
    }

    private IEnumerator MoveCloud(Vector2 start, Vector2 end)
    {
        float elapsedTime = 0;
        float duration = 1f; // ������ �̵��ϴ� �� �ɸ��� �ð�

        while (elapsedTime < duration)
        {
            cloud.transform.position = Vector2.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cloud.transform.position = end;
    }
}