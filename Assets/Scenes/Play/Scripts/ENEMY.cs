using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY : MonoBehaviour
{
    //public string targetobjectName;     //目標オブジェクト名 
    public GameObject targetObject;    //追いかける対象
    [SerializeField]private float speed = 3;            //追いかけるスピード

    //GameObject[] target;
    // Start is called before the first frame update
    void Start()
    {
        //targetObject = GameObject.Find(targetobjectName);
        targetObject = GameObject.FindWithTag("Player");
    }


    private void FixedUpdate()//ずっと、目標オブジェクトtの方向を調べる
    {
        Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;

        //その方向へ指定した量で進む
        float vx = dir.x * speed * Time.deltaTime;
        float vy = dir.y * speed * Time.deltaTime;
        this.transform.Translate(vx / 50, vy / 50, 0);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
