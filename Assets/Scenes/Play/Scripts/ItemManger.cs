using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManger : MonoBehaviour
{
    [SerializeField] GameObject Item;
    private const int SpawnNum = 5;
    GameObject[] Items = new GameObject[SpawnNum];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < SpawnNum; i++)
        {
            Items[i] = Instantiate(Item);
            Items[i].SetActive(false);
        }
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        Debug.Log("�Ă΂ꂽ");
        for(int i = 0; i < SpawnNum; i++)
        {
                Items[i].SetActive(true);
                float posx = Random.Range(-20f, 20f);
                float posy = Random.Range(-20f, 20f);
                Items[i].transform.position = new Vector3(posx, posy, 10);
        }
    }
}
