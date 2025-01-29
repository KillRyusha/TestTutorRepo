using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;
    public int damage = 20; // Урон пули

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
        if (collision.CompareTag("Enemy")) // Если попали во врага
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else if (!collision.CompareTag("Player")) // Чтобы не уничтожать игрока
        {
            Destroy(gameObject);
        }
    }
}

