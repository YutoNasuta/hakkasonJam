using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private ObejectPoller poller;
    [SerializeField] GameObject Player;
    [SerializeField]float ShotCom = 1f;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
        poller = GetComponent<ObejectPoller>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            // カーソル位置をワールド座標に変換
            Vector2 target = Camera.main.ScreenToWorldPoint(mousePosition);
            Shot(target);
            
        }
    }

    public void Shot(Vector2 target)
    {
        if(ShotCom <= timer)
        {
            timer = 0;
            Debug.Log("u");
            //Debug.Log("売った");
            GameObject bullet = poller.getObjectFromPool();
            Bullet newinstance = bullet.GetComponent<Bullet>();
            bullet.SetActive(true);
            
            newinstance.Shot(target);
        }
        
    }


}
