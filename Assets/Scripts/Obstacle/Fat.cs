using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fat : ObstacleAbstract
{
    [SerializeField]
    private int damage = 1;

    public override void ObstacleMove()
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GameManager.ObjectTag.Player.ToString()))
            ObstacleAttack(damage);
    }
}
