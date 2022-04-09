using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager instance;

    public static ObjectPoolManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<ObjectPoolManager>();
                if (instance == null)
                    Debug.Log("No Singleton Obj");
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        // DontDestroyOnLoad(gameObject);   // If you wanna maintain gamemanager to next scene, delete comment out
    }

    // Write your code under the here!!
    public ObjectPool pool;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
            ObjectPoolManager.Instance.pool
                .Dequeue(ObjectPoolManager.Instance.pool.selectPoolObjList(0))
                .transform.position = gameObject.transform.position;

        if (Input.GetKeyUp(KeyCode.Alpha2))
            ObjectPoolManager.Instance.pool
                .Dequeue(ObjectPoolManager.Instance.pool.selectPoolObjList(1))
                .transform.position = gameObject.transform.position;

        if (Input.GetKeyUp(KeyCode.Alpha3))
            ObjectPoolManager.Instance.pool
                .Dequeue(ObjectPoolManager.Instance.pool.selectPoolObjList(2))
                .transform.position = gameObject.transform.position;
    }
}
