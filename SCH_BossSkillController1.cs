using System.Collections;
using UnityEngine;

public class SCH_BossSkillController1 : MonoBehaviour
{
    public GameObject objectPrefab;   // 생성할 오브젝트 프리팹
    public float spawnInterval = 5f;  // 생성 간격
    public float spawnDelay = 0.5f;   // 오브젝트 생성 시간 간격
    public int objectCount = 3;       // 생성할 오브젝트 수

    private Vector3 bossPosition;     // 보스 위치
    private Coroutine spawnCoroutine; // 코루틴 변수

    void Start()
    {
        // 일정한 간격으로 오브젝트 생성하기
        spawnCoroutine = StartCoroutine(SpawnObject());
    }

    void FixedUpdate()
    {
        // 보스 위치 추적하기
        bossPosition = transform.position;
    }

    IEnumerator SpawnObject()
    {
        while (true)
        {
            // Player 오브젝트가 활성화되어 있을 때에만 생성하기
            if (GameObject.FindWithTag("Human").activeInHierarchy)
            {
                // 일정한 간격으로 오브젝트 생성하기
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
        // 오브젝트 생성하기
        Vector3 spawnPosition = bossPosition + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f);

        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
    }

    void OnDisable()
    {
        // Player 오브젝트가 비활성화되면 코루틴도 중지하기
        StopCoroutine(spawnCoroutine);
    }
}
