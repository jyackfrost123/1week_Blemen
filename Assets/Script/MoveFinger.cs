using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class MoveFinger : MonoBehaviour
{
    //RectTransformを取得する
    RectTransform rectTransform;

    Tween movetween;

    private Vector3 firstPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        firstPos = rectTransform.localPosition;
        movetween = rectTransform.DOAnchorPos(new Vector2(-198.0f, 26.0f), 0.6f).SetLoops(-1, LoopType.Yoyo);
        movetween.Pause();//スタートはさせておく
        this.gameObject.SetActive(true);
    }

    void Start()
    {
        
    }

    void OnEnable()
    {
        rectTransform.localPosition = firstPos;
        movetween = rectTransform.DOAnchorPos(new Vector2(-198.0f, 26.0f), 0.6f).SetLoops(-1, LoopType.Yoyo);
    }

    void OnDisable()
    {
        movetween.Pause();
    }
    
}
