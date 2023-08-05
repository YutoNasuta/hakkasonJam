using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int currenntWave = 1;
    [SerializeField] float exhau;
    private float currentExhau;
    [SerializeField] Image Clothbar;
    // Start is called before the first frame update
    void Start()
    {
        currentExhau = exhau;
    }

    // Update is called once per frame
    void Update()
    {
        currentExhau -= Time.deltaTime;
        Clothbar.fillAmount = currentExhau / exhau;
    }

    public void NextWave()
    {
        currenntWave++;
    }

    public int getWave()
    {
        return currenntWave;
    }

    public float getExharPer()
    {
        return currentExhau / exhau;
    }
}
