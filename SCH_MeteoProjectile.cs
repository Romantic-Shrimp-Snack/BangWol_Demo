using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class MeteoProjectile : MonoBehaviour
{
    //�÷����̾� ������ �������� ������Ʈ
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
    //������Ʈ�� �浹 �� ȣ��
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Human"))
        {
            // �÷��̾�� ������ ����
            other.GetComponent<Player>().TakeDamage(damage);
            Debug.Log("Player Health: " + other.GetComponent<Player>().health);
            Destroy(gameObject);
        }
    }
}
