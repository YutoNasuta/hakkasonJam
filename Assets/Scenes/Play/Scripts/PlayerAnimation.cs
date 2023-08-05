using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    [SerializeField]GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float per = gameManager.getExharPer();
        if (per >= 0.8) return;
        if (per >= 0.6)
        {
            animator.SetTrigger("State1");
            return;
        }
        if (per >= 0.4) {
            animator.SetTrigger("State2");
            return;
        }
        if (per >= 0.2) { 
            animator.SetTrigger("State3");
            return;
        }
        animator.SetTrigger("State4");

        

        
        
    }

    public void Reset()
    {
        animator.SetTrigger("Reset");
    }
}
