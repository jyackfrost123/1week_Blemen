using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CountDownPlayer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI uiText;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject firstRoba;
    
    [SerializeField] private UIController ui;
    [SerializeField] private GameObject seObject;
    
    [SerializeField] private GameObject robaFirstVoise;

    private parametorController para;

    [SerializeField]private playerController playerController;
    
    private void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
        uiText = this.GetComponent<TextMeshProUGUI>();

        playerController = GameObject.Find("Canvas").GetComponent<playerController>();
        
        if(GameObject.Find("NCMBSettings") != null){
            para = GameObject.Find("NCMBSettings").GetComponent<parametorController>(); 
        }

        PlayCountDown();
    }

    private void PlayCountDown()
    {
        var sequence = DOTween.Sequence();

        sequence
            .OnStart(() => UpdateText("3"))
            .Append(FadeOutText())
            .AppendCallback(() => UpdateText("2"))
            .AppendCallback(() => ComeFirstRoba())
            .AppendCallback(() => FadeOutText())
            .Append(FadeOutText())
            .AppendCallback(() => UpdateText("1"))
            .AppendCallback(() => CallRoba())
            .AppendCallback(() => addFirstAnimalNum())
            .Append(FadeOutText())
            .AppendCallback(() => UpdateText("START"))
            .AppendCallback(() => FlagChangeStart())
            .Append(FadeOutText())
            .OnComplete(() => ResetStartText());
    }

    //テキストの更新
    private void UpdateText(string text)
    {
        InitializeAlpha();

        uiText.text = text;
    }

    //フェードアウトさせる
    private Tween FadeOutText()
    {
        return uiText.DOFade(0, 0.8f).SetEase(Ease.InExpo);
    }

    //アルファ値の初期化
    private void InitializeAlpha()
    {
        uiText.color  = new Color(uiText.color.r, uiText.color.g, uiText.color.b, 1.0f);
    }

    //ゲームスタート
    private void FlagChangeStart()
    {
        //uiコントローラあたりのisGameStartをTrueにする
        ui.isGameStart = true;
        
        //スコアを0に戻す
        if (para != null) para.TotalScore = 0.0f;
        
        //ゴングを鳴らす
        CallSE();
    }
    
    //ゲーム開始時のSEを鳴らす
    private void CallSE()
    {
        Instantiate(seObject, Vector3.zero, Quaternion.identity);
    }

    //ロバの声を鳴らす
    private void CallRoba()
    {
        Instantiate(robaFirstVoise, Vector3.zero, Quaternion.identity);
    }
    
    //ゲームスタート前に最初のロバを入場させる
    private Tween ComeFirstRoba()
    {
        return firstRoba.transform.DOMoveX(player.transform.position.x, 1.2f).SetEase(Ease.InExpo);
    }

    private void addFirstAnimalNum()
    {
        playerController.AnimalNum++;
        playerController.getFirstAnimalTotalHight();
    }

    //中身を空文字にしてfinish時の演出に備える
    private Tween ResetStartText()
    {
        uiText.text = "";
        return uiText.DOFade(1, 0.1f).SetEase(Ease.InExpo);
    }

}
