using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shot(Vector2 target)
    {
        
        transform.position = Vector2.MoveTowards(transform.position,
        target, speed * Time.deltaTime);

    }
}
