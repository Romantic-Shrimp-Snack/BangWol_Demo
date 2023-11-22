using System.Collections;
using UnityEngine;

public class SCH_BossSkillController1 : MonoBehaviour
{
    public GameObject objectPrefab;   // ������ ������Ʈ ������
    public float spawnInterval = 5f;  // ���� ����
    public float spawnDelay = 0.5f;   // ������Ʈ ���� �ð� ����
    public int objectCount = 3;       // ������ ������Ʈ ��

    private Vector3 bossPosition;     // ���� ��ġ
    private Coroutine spawnCoroutine; // �ڷ�ƾ ����

    void Start()
    {
        // ������ �������� ������Ʈ �����ϱ�
        spawnCoroutine = StartCoroutine(SpawnObject());
    }

    void FixedUpdate()
    {
        // ���� ��ġ �����ϱ�
        bossPosition = transform.position;
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            // Player ������Ʈ�� Ȱ��ȭ�Ǿ� ���� ������ �����ϱ�
            if (GameObject.FindWithTag("Human").activeInHierarchy)
            {
                // ������ �������� ������Ʈ �����ϱ�
                for (int i = 0; i < objectCount; i++)
                {
                    CreateObject();
                    yield return new WaitForSeconds(spawnDelay);
                }
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void CreateObject()
    {
        // ������Ʈ �����ϱ�
        Vector3 spawnPosition = bossPosition + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f);

        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }

    void OnDisable()
    {
        // Player ������Ʈ�� ��Ȱ��ȭ�Ǹ� �ڷ�ƾ�� �����ϱ�
        StopCoroutine(spawnCoroutine);
    }
}
