using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY : MonoBehaviour
{
    //public string targetobjectName;     //�ڕW�I�u�W�F�N�g�� 
    public GameObject targetObject;    //�ǂ�������Ώ�
    [SerializeField]private float speed = 3;            //�ǂ�������X�s�[�h

    //GameObject[] target;
    // Start is called before the first frame update
    void Start()
    {
        //targetObject = GameObject.Find(targetobjectName);
        targetObject = GameObject.FindWithTag("Player");
    }


    private void FixedUpdate()//�����ƁA�ڕW�I�u�W�F�N�gt�̕����𒲂ׂ�
    {
        Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;

        //���̕����֎w�肵���ʂŐi��
        float vx = dir.x * speed * Time.deltaTime;
        float vy = dir.y * speed * Time.deltaTime;
        this.transform.Translate(vx / 50, vy / 50, 0);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
