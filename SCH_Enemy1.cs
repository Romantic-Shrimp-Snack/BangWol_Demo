using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class SCH_Enemy1 : MonoBehaviour
{
    public Rigidbody2D target;   //목표
     
    bool isLive= true   ;        //생존 여부
    public float health;
    public float maxHealth;

    //컨트롤 할 컴포넌트
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
        //몬스터 애니메이션 spriter.flipX 활성화 및 비활성화
        if (!isLive)
            return;
        spriter.flipX = target.position.x > rigid.position.x;
    }

    // Bullet오브젝트(삽)과 닿을시 실행 함수 피격 판정 및 죽는 판정
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
