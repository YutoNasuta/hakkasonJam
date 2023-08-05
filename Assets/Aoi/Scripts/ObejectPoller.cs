using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObejectPoller : MonoBehaviour
{
    //��������A�C�e��
    [SerializeField] private GameObject pollObject;
    [SerializeField] private int pollSize = 100;
    //�����������̂��Ǘ����郊�X�g
    private List<GameObject> pool;
    //�e�I�u�W�F�N�g�i�[
    private GameObject poolContainer;

    private void Awake()
    {
        //�C���X�^���X��
        pool = new List<GameObject>();

        //�I�u�W�F�N�g�������Ė��O��t���ĕϐ��Ɋi�[
        poolContainer = new GameObject($"Pool - {pollObject.name}");

        //�v�[���I�u�W�F�N�g�̍쐬
        CreatePooler();
    }

    private void CreatePooler()
    {
        for (int i = 0; i < pollSize; i++)
        {
            //�������Ċi�[
            pool.Add(CreateObject());
        }
    }

    private GameObject CreateObject()
    {
        GameObject newInstance = Instantiate(pollObject);

        //�e�̐ݒ�
        newInstance.transform.SetParent(poolContainer.transform);

        //��\��
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
