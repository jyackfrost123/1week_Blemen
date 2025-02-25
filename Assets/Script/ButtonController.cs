using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

   parametorController para;
   //public GameObject[] Omakes;

   [SerializeField] private GameObject tutorialImage;


   void Start()
    {
     
     if(GameObject.Find("NCMBSettings") != null){
         para = GameObject.Find("NCMBSettings").GetComponent<parametorController>(); 
     }

     if (tutorialImage != null)
     {
         tutorialImage.SetActive(false);
     }


    }

    public void goTweet(){
       //naichilab.UnityRoomTweet.Tweet ("gameID", "このゲームは"+100+"点"+"とったテストです。", "unity1week", "testGame");
       StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("私のブレーメンの音楽隊は、"+para.TotalAnimalNum+"匹で、"+para.TotalScore+"mのくそでか音楽隊になりました。(ゲームURL⇒ https://unityroom.com/games/kusodeka_animaltower ) "));//画像あり
    }

    public void goRanking(){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 0);
    }

    public void goResult(int score){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.TotalScore, 0);
    }
    
    
    /*
    public void go2ndRanking(){
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 1);
    }

    public void go2ndResult(int score){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (score, 1);
    }
    */
    

    public void ReStart(){
        FadeManager.Instance.LoadScene ("GameScene", 0.5f);

        
        /*if(para != null && para.NotFirst == false){
            //チュートリアルのロード
            FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
            para.NotFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("GameScene", 1.0f);
        }*/
        
    }

    public void FastReStart(){
         SceneManager.LoadScene("GameScene");
    }

    /*
    public void Re2ndStart(){

        //FadeManager.Instance.LoadScene ("EndressGameScene", 1.0f);

        if(para != null && para.notFirst == false){
            FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
            para.notFirst = true;
        }else{
          FadeManager.Instance.LoadScene ("EndressGameScene", 1.0f);
        }
    }*/

     /*public void Fast2ndReStart(){
         SceneManager.LoadScene("EndressGameScene");
    }*/

    public void goTutorial(){
        //FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
        tutorialImage.SetActive(true);
    }
    
    public void endTutorial(){
        //FadeManager.Instance.LoadScene ("Tutorial", 0.5f);
        tutorialImage.SetActive(false);
    }

    public void goTitle(){
        FadeManager.Instance.LoadScene ("Title", 0.5f);
    }

 
}
