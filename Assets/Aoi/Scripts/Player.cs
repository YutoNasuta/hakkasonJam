using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;
    private GameObject m_object;
    Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        m_object = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        InMap();
       
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(Vector3.up * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.down * Time.deltaTime * Speed);
        }
    }

    void InMap()
    {
        currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, -10.6f, 10.6f);
        
        currentPos.y = Mathf.Clamp(currentPos.y, -9.9f, 9.9f);

        transform.position = currentPos;
    }
}
