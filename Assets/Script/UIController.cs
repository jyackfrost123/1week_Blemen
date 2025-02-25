using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    
    [SerializeField]
    private TextMeshProUGUI animalNumText;
    
    [SerializeField]
    private TextMeshProUGUI timerText;
    
    [SerializeField]
    private TextMeshProUGUI gameOverText;

    [SerializeField] 
    private playerController player;

    [SerializeField]
    private GameObject endSE;

    [field: SerializeField] public bool isGameStart;
    [field: SerializeField] public float time; 
    
    private parametorController para;

    [SerializeField] private GameObject sumahoButton;
    
    // Start is called before the first frame update
    void Start()
    {
        isGameStart = false;
        
        if(GameObject.Find("NCMBSettings") != null){
            para = GameObject.Find("NCMBSettings").GetComponent<parametorController>();
            //ゲーム開始時のスコア初期化
            para.TotalAnimalNum = 0;
            para.TotalScore = 0.0f;

            if (para.IsSumaho)
            {
                sumahoButton.SetActive(true);
            }
            else
            {
                sumahoButton.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (isGameStart)
        {
            time -= Time.deltaTime;
            if (time < 0.0f)
            {
                time = 0;
                isGameStart = false;
                GameFinish();
                DOVirtual.DelayedCall (3.0f, ()=> DoChangeScene());  
                //GameFinish();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = "高さ: "+player.AnimalTotalHight.ToString("f2")+"m";
        timerText.text = "残り: " + time.ToString("f2") + "秒";
        if (time < 5.9f)
        {
            timerText.color = Color.red;
        }
        animalNumText.text = "現在: " + player.AnimalNum +" 匹目";
    }

    void GameEndScore()
    {
        para.TotalScore = player.AnimalTotalHight;
    }

    //ゲーム終了時の処理
    void GameFinish()
    {
        gameOverText.text = "FINISH!";
        gameOverText.color = Color.yellow;
        para.TotalScore = player.AnimalTotalHight;
        para.TotalAnimalNum = player.AnimalNum;
        Instantiate(endSE, Vector3.zero, Quaternion.identity);
        
    }

    void DoChangeScene()
    {
        //フェード遷移とか入れる
        FadeManager.Instance.LoadScene ("Ending", 1.5f);
    }
}
