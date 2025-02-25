using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpningMove : MonoBehaviour
{
    //RectTransformを取得する
    Transform animalTansform;

    private Vector3 firstPos;
    

    [SerializeField] private float hightpoint;
    [SerializeField] private float durationTime = 3.0f;

    private void Awake()
    {
        animalTansform = this.transform;
        firstPos = animalTansform.position;
        animalTansform.DOMoveY(firstPos.y + hightpoint, durationTime).SetLoops(-1, LoopType.Yoyo);
        //this.gameObject.SetActive(true);
    }
}
