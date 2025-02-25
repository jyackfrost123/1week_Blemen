using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using unityroom.Api;

public class EndingController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    
    [SerializeField]
    private TextMeshProUGUI animalNumText;
    
    [SerializeField]
    private TextMeshProUGUI evaluatinoText;

    [SerializeField] public GameObject firstObject;

    [SerializeField] public GameObject endObject;

    [SerializeField] public GameObject startTouzoku;
    [SerializeField] public GameObject endTouzoku;
    [SerializeField] public GameObject touzokuSE;

    [SerializeField] private GameObject mainCamera;

    [SerializeField] public float TotalAnimalHight { get; set; }
    [SerializeField] public int FinalAnimalNum { get; set; }

    [SerializeField] private float cameraRobaMergin;

    [SerializeField] private float effectDelaySeq = 1.5f;
    [SerializeField] private float effectShowSeq = 1.0f;

    [SerializeField] private GameObject explosionObject;
    [SerializeField] private GameObject[] animalFinalSE;

    private float viewTotalScore;
    private int viewTotalAnimalNum;

    [SerializeField] private GameObject EndingSE;

    [SerializeField]
    private GameObject finishBGM;

    [SerializeField] private GameObject endingEvaluation;
    [SerializeField] private int[] evaluationPoint;
    [SerializeField] private string[] evaluationString;
    

    private parametorController para;
    // Start is called before the first frame update
    void Start()
    {
        para = GameObject.Find("NCMBSettings").GetComponent<parametorController>();
        TotalAnimalHight = para.TotalScore;
        FinalAnimalNum = para.TotalAnimalNum;
        
        endingEvaluation.SetActive(false);

        viewTotalScore = 0.0f;
        viewTotalAnimalNum = 0;

        Vector3 cameraFirstPos = mainCamera.transform.position;
        mainCamera.transform.position = new Vector3(cameraFirstPos.x, firstObject.transform.position.y + cameraRobaMergin, cameraFirstPos.z);
        
        UnityroomApiClient.Instance.SendScore(1, TotalAnimalHight, ScoreboardWriteMode.HighScoreDesc);//Ranking

        routTouzoku();//盗賊逃げる

        DOVirtual.DelayedCall(effectDelaySeq, () =>
        {
            EndingEffect();
            ScoreEffect();
            AnimalNumEffect();
        });

        //EndingEffect();//ブレーメンを下から見上げる
        //ScoreEffect();
        //AnimalNumEffect();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //scoreText.text = "高さ: "+ viewTotalScore.ToString("f2")+"m";//viewTotalScore
        //animalNumText.text = "合計: " + viewTotalAnimalNum +" 匹";//viewTotalAnimalNum
    }
    
    private void EndingEffect()
    {
        var sequence = DOTween.Sequence();

        sequence
            .OnStart(() => Debug.Log("Ending!"))
            .Append(FadeOutText())
            .AppendCallback(() =>
            {
                int i = para.TotalAnimalNum % 4;
                if (i != 0) i--;
                else i = 3;
                //1つ戻す
                Debug.Log(i);
                explosionObject = animalFinalSE[i];

                Destroy(EndingSE);
                seCall(finishBGM);
                SetEvaluation();
                
                seCall(explosionObject);
            });
    }
    
    private Tween FadeOutText()
    {
        return mainCamera.transform.DOMoveY(endObject.transform.position.y, effectShowSeq).SetEase(Ease.InExpo).SetDelay(effectDelaySeq);
    }
    
    //スコアカウントアップ
    private void ScoreEffect(){
        //DoVirtual?
        DOVirtual.Float(0, para.TotalScore, effectShowSeq, value =>
            {
                scoreText.text = "高さ: "+ value.ToString("f2")+"m";//viewTotalScore
            }
        ).SetDelay(effectDelaySeq)
            .OnComplete(() =>
        {
            scoreText.text = "高さ: "+ para.TotalScore.ToString("f2")+"m";//viewTotalScore
        });;
    }

    //動物数カウントアップ
    private void AnimalNumEffect(){
        //DoVirtual?
        DOVirtual.Int(0, para.TotalAnimalNum, effectShowSeq, value =>
            {
                animalNumText.text = "合計: "+ value.ToString()+"匹";//viewTotalScore
            }
        ).SetDelay(effectDelaySeq)
            .OnComplete(() =>
        {
            animalNumText.text = "合計: "+ para.TotalAnimalNum.ToString()+"匹";//viewTotalScore
        });
    }
    
    //    
    private Tween routTouzoku()
    {
        seCall(touzokuSE);
        //DoMoveZ?SetDelayの時間周り？
        return startTouzoku.transform.DOMoveX(endTouzoku.transform.position.x, effectDelaySeq).SetEase(Ease.InExpo).SetDelay(0.1f);
    }

    //爆発演出、逃走SEとか
    private void seCall(GameObject obj){
        Instantiate(obj, endObject.transform.position, Quaternion.identity);
    }

    private void SetEvaluation()
    {
        endingEvaluation.SetActive(true);
        string evalu = "";

        for(int j = 0; j < evaluationPoint.Length; j++)
        {
            if (para.TotalScore >= evaluationPoint[j])
            {
                evalu = evaluationString[j];
            }
        }
        evaluatinoText.text = "ブレーメンの\n"+evalu+"\n音楽隊";
        Debug.Log(evalu);
        
    }
    
    //

}
