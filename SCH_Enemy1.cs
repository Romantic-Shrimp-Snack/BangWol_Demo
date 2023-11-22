using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class SCH_Enemy1 : MonoBehaviour
{
    public Rigidbody2D target;   //��ǥ
     
    bool isLive= true   ;        //���� ����
    public float health;
    public float maxHealth;

    //��Ʈ�� �� ������Ʈ
    Rigidbody2D rigid;
    SpriteRenderer spriter;

    // Start is called before the first frame update
    void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
        spriter= GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        //���� �ִϸ��̼� spriter.flipX Ȱ��ȭ �� ��Ȱ��ȭ
        if (!isLive)
            return;
        spriter.flipX = target.position.x > rigid.position.x;
    }

    // Bullet������Ʈ(��)�� ������ ���� �Լ� �ǰ� ���� �� �״� ����
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (!collision.CompareTag("Bullet") || !isLive) return;
    //    health -= collision.GetComponent<Bullet>().damage;
    //    StartCoroutine(KnockBack());

    //    if (health > 0)
    //    {
    //        anim.SetTrigger("Hit");
    //    }
    //    else
    //    {
    //        isLive = false;
    //        coll.enabled = false;
    //        rigid.simulated = false;
    //        spriter.sortingOrder = 1;
    //        anim.SetBool("Dead", true);
    //        GameManager.instance.kill++;
    //        GameManager.instance.GetExp();
    //    }
    //}

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
            GameManager.instance.GameVictroy();
        }

    }

}
