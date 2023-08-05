using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveText : MonoBehaviour
{
    TextMeshProUGUI m_TextMeshProUGUI;
    int currentWave = 1;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        m_TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        m_TextMeshProUGUI.text = "WAVE " + currentWave.ToString();
        if(timer > 3) { 
            gameObject.SetActive(false);
            timer = 0;
        }
    }

    public void WaveStart(int i)
    {
        gameObject.SetActive(true);
        currentWave = i;
    }
}
