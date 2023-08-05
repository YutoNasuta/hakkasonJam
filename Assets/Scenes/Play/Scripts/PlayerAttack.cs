using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject ball;
    [SerializeField]float speed =10.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // �e�i�Q�[���I�u�W�F�N�g�j�̐���
            GameObject clone = Instantiate(ball, transform.position, Quaternion.identity);

            // �N���b�N�������W�̎擾�i�X�N���[�����W���烏�[���h���W�ɕϊ��j
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // �����̐����iZ�����̏����Ɛ��K���j
            Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

            // �e�ɑ��x��^����
            clone.GetComponent<Rigidbody2D>().velocity = shotForward * speed * Time.deltaTime;

        }
    }
}
