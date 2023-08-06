using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int GetCloth = 0;
    [SerializeField] private float Speed;
    private GameObject m_object;
    Vector3 currentPos;
    private float HP = 500;
    private float currentHP = 0;
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerAnimation Animation;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHP = HP;
        GetCloth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        InMap();
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

        if (leftStickValue.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }

        if(currentHP <= 0)
        {
            GameManager.ScorePoint = 10;
            gameManager.GameFinish();
        }
    }

    void InMap()
    {
        currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -24f, 24f);
        
        currentPos.y = Mathf.Clamp(currentPos.y, -24f, 24f);

        transform.position = currentPos;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")){
            currentHP -= 4 * (1.1f - gameManager.getExharPer());
        }
        
        if(collision.CompareTag("Item"))
        {
            gameManager.Repair();
            Animation.Reset();
            collision.gameObject.SetActive(false);
            GetCloth++;
        }
    }

    public float GetHPPer()
    {
        return currentHP / HP;
    }
}
