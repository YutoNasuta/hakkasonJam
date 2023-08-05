using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObejectPoller : MonoBehaviour
{
    //生成するアイテム
    [SerializeField] private GameObject pollObject;
    [SerializeField] private int pollSize = 100;
    //生成したものを管理するリスト
    private List<GameObject> pool;
    //親オブジェクト格納
    private GameObject poolContainer;

    private void Awake()
    {
        //インスタンス化
        pool = new List<GameObject>();

        //オブジェクト生成して名前を付けて変数に格納
        poolContainer = new GameObject($"Pool - {pollObject.name}");

        //プールオブジェクトの作成
        CreatePooler();
    }

    private void CreatePooler()
    {
        for (int i = 0; i < pollSize; i++)
        {
            //生成して格納
            pool.Add(CreateObject());
        }
    }

    private GameObject CreateObject()
    {
        GameObject newInstance = Instantiate(pollObject);

        //親の設定
        newInstance.transform.SetParent(poolContainer.transform);

        //非表示
        newInstance.SetActive(false);

        return newInstance;
    }

    public GameObject getObjectFromPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        return CreateObject();
    }

    public static void RetrunToPool(GameObject instance)
    {
        instance.SetActive(false);
    }
}
