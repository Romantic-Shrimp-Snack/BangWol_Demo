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
            //���Ѹ� ���ġ
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
                //�÷��̾ �������׼� �ʹ� �ָ��������� ������ġ �̵�
            case "Enemy":
                if (coll.enabled)
                {
                    //                   �÷��̾� ���⿡ �� �ϳ���ŭ �������� �̵�  
                    transform.Translate(playerDir * 30 + new Vector3(Random.Range(-3f,3f), Random.Range(-3f, 3f),0f));
                }
                break;
        }
    }
}
