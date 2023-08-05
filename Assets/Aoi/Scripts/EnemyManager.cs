using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]GameManager gameManager;
    [SerializeField] GameObject Player;
    private int plusenemy = 5;
    private ObejectPoller Poller;
    [SerializeField] private int StartEnemyNum = 10;
    private int spawnEnemy;
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
        for (int i = 0; i < spawnEnemy; i++)
        {
            GameObject newinstance = Poller.getObjectFromPool();
            if (newinstance.activeInHierarchy) continue;
            gameManager.NextWave();
            spawnEnemy = StartEnemyNum + plusenemy * gameManager.getWave();
            Spaw();
        }
        //if(Input.GetKeyDown(KeyCode.L))
        //{
        //    gameManager.NextWave();
        //    spawnEnemy = StartEnemyNum + plusenemy * gameManager.getWave();
        //    Spaw();
        //}
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
        float dicex = Random.Range(-6f,6f);
        float dicey = Random.Range(-6f,6f);
        //dicex = Mathf.Clamp(dicex, -6f, -3f);
        //dicex = Mathf.Clamp(dicex, 3f, 6f);
        //dicey = Mathf.Clamp(dicey, -6f, -3f);
        //dicey = Mathf.Clamp(dicey, 3f, 6f);

        instance.transform.position = new Vector3(Player.transform.position.x + dicex,
            Player.transform.position.y + dicey, transform.position.z);
        
    }
}
