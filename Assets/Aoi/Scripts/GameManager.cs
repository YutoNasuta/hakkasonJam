using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int currenntWave = 1;
    [SerializeField] float exhau;
    private float currentExhau;
    [SerializeField] Image Clothbar;
    [SerializeField]private ItemManger ItemManger;
    private float timer = 180;
    [SerializeField] TextMeshProUGUI TTime;
    [SerializeField] TextMeshProUGUI TCloth;
    [SerializeField] TextMeshProUGUI Tscore;
    [SerializeField] WaveText waveText;
    public static int score;
    // Start is called before the first frame update
    void Start()
    {
        currentExhau = exhau;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentExhau -= Time.deltaTime;
        Clothbar.fillAmount = currentExhau / exhau;
        timer -= Time.deltaTime;
        if(timer > 180) {
            GameFinish();
        }
        TextUpdate();
    }

    public void NextWave()
    {
        currenntWave++;
        waveText.WaveStart(currenntWave);
        ItemManger.Spawn();
    }

    public int getWave()
    {
        return currenntWave;
    }

    public float getExharPer()
    {
        return currentExhau / exhau;
    }

    void GameFinish()
    {

    }

    public void Repair()
    {
        currentExhau = exhau;
    }

    private void TimeText()
    {
        int minutes = (int)timer / 60;
        int seconds = (int)timer % 60;
        TTime.text = minutes.ToString()+":" + seconds.ToString();
        if(seconds < 10)
        {
            TTime.text = minutes.ToString() + ":0" + seconds.ToString();
        }
    }

    private void ClothText()
    {
        TCloth.text = "~ " + Player.GetCloth.ToString();
    }

    private void ScoreText()
    {
        Tscore.text = "SCORE:" + score.ToString();
    }

    void TextUpdate()
    {
        TimeText();
        ClothText();
        ScoreText();
    }

    public void GetScore(int i)
    {
        score += i;
    }
}
