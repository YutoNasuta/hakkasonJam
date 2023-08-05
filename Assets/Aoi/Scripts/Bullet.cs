using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]Animator m_Animator;
    private float timer;
    Rigidbody2D m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3)
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_Animator.SetTrigger("Get");
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Enemy"))
        {
            m_Animator.SetTrigger("Get");
           m_Rigidbody.velocity = Vector3.zero;
            
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
