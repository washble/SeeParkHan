using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPoolPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject leftFloor;
    [SerializeField]
    private GameObject rightFloor;

    private GameObject poolingObject;
    private int minRandom = 1;
    private int MaxRandom = 5;

    void Awake()
    {
        gameObject.GetComponent<Floors>().RePositionActive += CreateObstacles;
    }

    private void CreateObstacles(GameManager.Floors floor)
    {
        if (floor == GameManager.Floors.left) poolingObject = leftFloor;
        if (floor == GameManager.Floors.right) poolingObject = rightFloor;

        for(int i = 0; i <= Random.Range(minRandom, MaxRandom); i++)
        {
            GameObject tempObject = ObjectPoolManager.Instance.pool
                .Dequeue(ObjectPoolManager.Instance.pool.selectPoolObjList(0)).gameObject;
            tempObject.transform.parent = poolingObject.transform;
            tempObject.transform.position = poolingObject.transform.position + new Vector3(Random.Range(-25, 10), 2, 0);
        }
            
        for (int i = 0; i <= Random.Range(minRandom, MaxRandom); i++)
        {
            GameObject tempObject = ObjectPoolManager.Instance.pool
                .Dequeue(ObjectPoolManager.Instance.pool.selectPoolObjList(1)).gameObject;
            tempObject.transform.parent = poolingObject.transform;
            tempObject.transform.position = poolingObject.transform.position + new Vector3(Random.Range(-30, 15), 2, 0);
        }

        for (int i = 0; i <= Random.Range(minRandom, MaxRandom); i++)
        {
            GameObject tempObject = ObjectPoolManager.Instance.pool
                .Dequeue(ObjectPoolManager.Instance.pool.selectPoolObjList(2)).gameObject;
            tempObject.transform.parent = poolingObject.transform;
            tempObject.transform.position = poolingObject.transform.position + new Vector3(Random.Range(-30, 15), 2, 0);
        }
    }
}
