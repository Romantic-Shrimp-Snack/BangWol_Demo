using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class StoneProjectile : MonoBehaviour
{

    Rigidbody2D rigidbody2D;
    public int damage;

    public void Init(int damage)
    {
        this.damage = damage;
    }

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    //오브젝트에 가해진 힘
    //캐릭터 방향, 가해질 힘
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2D.AddForce(direction * force);
    }


    void Update()
    {
        //position은 월드의 중심에서부터 오브젝트의 위치
        //magnitude는 해당 벡터의 길이가 된다
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    //오브젝트에 충돌 시 호출
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // 보스 몬스터에게 데미지 적용
            other.GetComponent<Enemy1>().TakeDamage(damage);
            Debug.Log("Boss Monster Health: " + other.GetComponent<Enemy1>().health);
            Destroy(gameObject);
        }
    }

}
