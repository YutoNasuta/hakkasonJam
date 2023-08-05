using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explanationScene : MonoBehaviour
{

    public GameObject targetObject;

    

    public void OnClick()
    {

        targetObject.SetActive(true);
        Debug.Log("!!!!");
    }
}
