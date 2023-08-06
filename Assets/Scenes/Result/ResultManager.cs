using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI Cloth;
    [SerializeField] TextMeshProUGUI ScoreFinish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "SCORE:" + GameManager.score.ToString();
        Cloth.text = "~ " + Player.GetCloth.ToString();
        int scorepoint = GameManager.ScorePoint;
        if(scorepoint > 10)scorepoint = 10;
        int scorefinish = GameManager.score * (11 - scorepoint);
        ScoreFinish.text = "TOTALSCORE:" + scorefinish.ToString();
    }

    public void ChangeTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
