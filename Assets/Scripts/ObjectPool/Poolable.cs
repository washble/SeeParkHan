using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    private ObjectPool pool;

    public void Create(ObjectPool pool)
    {
        this.pool = pool;
        gameObject.SetActive(false);
    }

    public void Enqueue()
    {
        pool.Enqueue(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameManager.ObjectTag.Player.ToString()))
            Enqueue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(GameManager.ObjectTag.Foot.ToString()))
        {
            Enqueue();
            GameManager.Instance.PlayerScore += 1;
        }

        if (collision.gameObject.CompareTag(GameManager.ObjectTag.Destroy.ToString()))
        {
            Enqueue();
        }
    }
}
