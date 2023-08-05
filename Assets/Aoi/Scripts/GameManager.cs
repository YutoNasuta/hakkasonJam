using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currenntWave = 1;
    [SerializeField] float exhau;
    private float currentExhau;
    // Start is called before the first frame update
    void Start()
    {
        currentExhau = exhau;
    }

    // Update is called once per frame
    void Update()
    {
        currentExhau -= Time.deltaTime;
        Debug.Log(currentExhau);
    }

    public void NextWave()
    {
        currenntWave++;
    }

    public int getWave()
    {
        return currenntWave;
    }
}
