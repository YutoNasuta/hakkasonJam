using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceenChange1 : MonoBehaviour
{
    public Image image; //�t�F�[�h�̃I�u�W�F�N�g
    public float fadeSpeed = 0.5f; // �A���t�@�l�̕ω����x
    public float MAXAlpha = 1f; // �A���t�@�l�̍ő�l
    public string nextSceneName; // �؂�ւ���V�[���̖��O

    private bool isFading = false; // �t�F�[�h�����ǂ����̃t���O

    public GameObject targetObject; //�t�F�[�h�̃I�u�W�F�N�g

    private void Start()
    {
        Color color = image.color;
        color.a = 0f; // ������Ԃł͓����ɂ���
        image.color = color;
    }

    private void Update()
    {
        if (isFading)�@�@//�t�F�[�h�̊J�n����
        {
            Fade();
        }
    }

    public void StartFade()�@
    {
        isFading = true;
    }

    private void Fade()
    {
        Color color = image.color;
        color.a += fadeSpeed * Time.deltaTime; // �A���t�@�l��ω�������

        Debug.Log("���̃A���t�@�l�F" + color.a);

        if (color.a >= MAXAlpha) // �A���t�@�l���ő�l�ɒB������V�[����؂�ւ���
        {
            Debug.Log("!!!!");
            SceneManager.LoadScene("SampleScene");�@//�V�[���J��
        }

        image.color = color;

    }

    public void OnClick()
    {
        //�Z�b�g�A�N�e�B�u
        targetObject.SetActive(true);�@
        Debug.Log("!!!!");
        StartFade();
    }
}
