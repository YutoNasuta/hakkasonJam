using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close : MonoBehaviour
{

    public GameObject targetObject;

    public void OnClick()
    {

        targetObject.SetActive(false);
        Debug.Log("close");
    }
}
