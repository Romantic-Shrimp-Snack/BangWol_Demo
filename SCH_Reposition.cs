using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1 ;
        float dirY = playerDir.y < 0 ? -1 : 1 ;

        switch (transform.tag)
        {
            //무한맵 재배치
            case "Ground":
                if(diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 60);
                }
                else if (diffY > diffX)
                {
                    transform.Translate(Vector3.up * dirY * 60);
                }

                break;
                //플레이어가 좀비한테서 너무 멀리떨어지면 좀비위치 이동
            case "Enemy":
                if (coll.enabled)
                {
                    //                   플레이어 방향에 맵 하나만큼 랜덤으로 이동  
                    transform.Translate(playerDir * 30 + new Vector3(Random.Range(-3f,3f), Random.Range(-3f, 3f),0f));
                }
                break;
        }
    }
}
