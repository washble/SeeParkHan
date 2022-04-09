using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private int allocateCount;
    [SerializeField]
    private List<Poolable> poolObjList = new List<Poolable>();

    private Dictionary<string, Queue<Poolable>> poolDictionary = new Dictionary<string, Queue<Poolable>>();

    void Start()
    {
        Init();
    }

    public Poolable selectPoolObjList(int num)
    {
        return poolObjList[num];
    }

    private void Init()
    {
        foreach(Poolable poolObj in  poolObjList)
        {
            Queue<Poolable> poolQueue = new Queue<Poolable>();
            for (int i = 0; i < allocateCount; i++)
            {
                Poolable allocateObj = Instantiate(poolObj, gameObject.transform);
                allocateObj.Create(this);
                allocateObj.name = poolObj.name;
                poolQueue.Enqueue(allocateObj);
            }
            poolDictionary.Add(poolObj.name, poolQueue);
        }
    }

    public GameObject Dequeue(Poolable poolObj)
    {
        if (poolDictionary.ContainsKey(poolObj.gameObject.name))
        {
            if (poolDictionary[poolObj.gameObject.name].Count > 0) 
            {
                GameObject obj = poolDictionary[poolObj.gameObject.name].Dequeue().gameObject;
                obj.SetActive(true);
                return obj;
            }
            else
            {
                Poolable poolableObj = Instantiate(poolObj, gameObject.transform);
                poolableObj.Create(this);
                poolableObj.name = poolObj.name;
                poolableObj.gameObject.SetActive(true);
                return poolableObj.gameObject;
            }
        }
        throw new Exception("No PoolObject!!!");
    }

    public void Enqueue(Poolable obj)
    {
        obj.gameObject.SetActive(false);
        if (poolDictionary.ContainsKey(obj.name))
            poolDictionary[obj.name].Enqueue(obj);
        else
            throw new Exception("It's not Pooling Object!!!");
    }
}
