using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour
{

    public string nextSceneName; // �؂�ւ���V�[���̖��O
    public void OnClick()
    {
        SceneManager.LoadScene(nextSceneName);�@//�V�[���J��
    }
}
