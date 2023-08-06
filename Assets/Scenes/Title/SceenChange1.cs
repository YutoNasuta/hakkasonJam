using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceenChange1 : MonoBehaviour
{
    public Image image; //フェードのオブジェクト
    public float fadeSpeed = 0.5f; // アルファ値の変化速度
    public float MAXAlpha = 1f; // アルファ値の最大値
    public string nextSceneName; // 切り替えるシーンの名前

    private bool isFading = false; // フェード中かどうかのフラグ

    public GameObject targetObject; //フェードのオブジェクト

    private void Start()
    {
        Color color = image.color;
        color.a = 0f; // 初期状態では透明にする
        image.color = color;
    }

    private void Update()
    {
        if (isFading)　　//フェードの開始判定
        {
            Fade();
        }
    }

    public void StartFade()　
    {
        isFading = true;
    }

    private void Fade()
    {
        Color color = image.color;
        color.a += fadeSpeed * Time.deltaTime; // アルファ値を変化させる

        Debug.Log("今のアルファ値：" + color.a);

        if (color.a >= MAXAlpha) // アルファ値が最大値に達したらシーンを切り替える
        {
            Debug.Log("!!!!");
            SceneManager.LoadScene("SampleScene");　//シーン遷移
        }

        image.color = color;

    }

    public void OnClick()
    {
        //セットアクティブ
        targetObject.SetActive(true);　
        Debug.Log("!!!!");
        StartFade();
    }
}
