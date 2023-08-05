using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    [SerializeField] GameObject Player;
    private int plusenemy = 3;
    private ObejectPoller Poller;
    [SerializeField] private int StartEnemyNum = 10;
    private int spawnEnemy;
    [SerializeField] private float SpawnMax;
    [SerializeField] private float SpawnMin;
    // Start is called before the first frame update
    void Start()
    {
        Poller = GetComponent<ObejectPoller>();
        spawnEnemy = StartEnemyNum;
        Spaw();
    }

    // Update is called once per frame
    void Update()
    {
        NextWave();
    }

    void Spaw()
    {
        for(int i = 0;i < spawnEnemy;i++)
        {
            GameObject newinstance = Poller.getObjectFromPool();
            SetEnemy(newinstance);
            newinstance.SetActive(true);
        }
    }

    void SetEnemy(GameObject instance)
    {
        float dicex;
        float dicey;
        if(Random.Range(2,10) % 2 == 0)
        {
            dicex = Random.Range(SpawnMin,SpawnMax);
        }
        else
        {
            dicex = Random.Range(-SpawnMax, -SpawnMin);
        }
        if (Random.Range(2, 10) % 2 == 0)
        {
            dicey = Random.Range(SpawnMin, SpawnMax);
        }
        else
        {
            dicey = Random.Range(-SpawnMax, -SpawnMin);
        }
        

        instance.transform.position = new Vector3(Player.transform.position.x + dicex,
            Player.transform.position.y + dicey, transform.position.z);

        if(gameManager.getWave() % 2 == 0)
        {
            ENEMY eNEMY = instance.GetComponent<ENEMY>();
            eNEMY.SetSpeed(0.3f);
        }
        
    }

    void NextWave()
    {
        int num = 0;
        for (int i = 0; i < spawnEnemy; i++)
        {

            GameObject newinstance = Poller.GetOvject(i);
            if (newinstance.activeInHierarchy) continue;
            num++;
            if (num >= spawnEnemy)
            {

                gameManager.NextWave();
                spawnEnemy = StartEnemyNum + plusenemy * gameManager.getWave();
                Spaw();
                return;
            }
        }
    }
}
