using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{

    public string nextSceneName; // 切り替えるシーンの名前
    public void OnClick()
    {
        SceneManager.LoadScene(nextSceneName);　//シーン遷移
    }
}
