using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;
    private GameObject m_object;
    Vector3 currentPos;
    [SerializeField] private float HP;
    [SerializeField] float currentHP;
    [SerializeField] GameManager gameManager;
    [SerializeField] Image HPbar;
    // Start is called before the first frame update
    void Start()
    {
        //m_object = GetComponent<GameObject>();
        currentHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Debug.Log(currentHP / HP);
    }


    void Move()
    {
        // 現在のゲームパッド情報
        var current = Gamepad.current;

        // ゲームパッド接続チェック
        if (current == null)
            return;

        // 左スティック入力取得
        var leftStickValue = current.leftStick.ReadValue();

        gameObject.transform.Translate(leftStickValue.x * Time.deltaTime * Speed,
            leftStickValue.y * Time.deltaTime * Speed,0);
    }

    void InMap()
    {
        currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -10.6f, 10.6f);
        
        currentPos.y = Mathf.Clamp(currentPos.y, -9.9f, 9.9f);

        transform.position = currentPos;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            currentHP -= 1/* * (1.1f - gameManager.getExharPer())*/;
        }
    }

    
}
