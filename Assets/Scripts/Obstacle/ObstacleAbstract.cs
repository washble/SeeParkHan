using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstacleAbstract : MonoBehaviour
{
    [SerializeField]
    private float movePower = 2;
    private float randomPower;

    private void Awake()
    {
        randomPower = Random.Range(1, 3) * 0.3f;
    }

    public abstract void ObstacleMove();

    public void ObstacleAttack(int damage)
    {
        GameManager.Instance.PlayerHP -= damage;
    }

    public void ObstacleDestory(GameObject obstacleObject)
    {
        obstacleObject.SetActive(false);
    }

    void Update()
    {
        Vector3 normalDirection = Vector3.left;
        if (GameManager.Instance.PlayerTransform.position.x - transform.position.x >= 0)
            normalDirection = Vector3.right;

        transform.position +=  normalDirection * movePower * randomPower * Time.deltaTime;
    }
}
