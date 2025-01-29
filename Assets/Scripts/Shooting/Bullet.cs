using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;
    public int damage = 20; // ���� ����

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // ���� ������ �� �����
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Player")) // ����� �� ���������� ������
        {
            Destroy(gameObject);
        }
    }
}

