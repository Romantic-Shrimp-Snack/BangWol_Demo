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


    //������Ʈ�� ������ ��
    //ĳ���� ����, ������ ��
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2D.AddForce(direction * force);
    }


    void Update()
    {
        //position�� ������ �߽ɿ������� ������Ʈ�� ��ġ
        //magnitude�� �ش� ������ ���̰� �ȴ�
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    //������Ʈ�� �浹 �� ȣ��
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // ���� ���Ϳ��� ������ ����
            other.GetComponent<Enemy1>().TakeDamage(damage);
            Debug.Log("Boss Monster Health: " + other.GetComponent<Enemy1>().health);
            Destroy(gameObject);
        }
    }

}
