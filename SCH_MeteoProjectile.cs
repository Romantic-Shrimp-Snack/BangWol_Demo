using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MeteoProjectile : MonoBehaviour
{
    //플레이이어 주위에 떨어지는 오브젝트
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
    //오브젝트에 충돌 시 호출
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Human"))
        {
            // 플레이어에게 데미지 적용
            other.GetComponent<Player>().TakeDamage(damage);
            Debug.Log("Player Health: " + other.GetComponent<Player>().health);
            Destroy(gameObject);
        }
    }
}
