using UnityEngine;
using System.Collections;
using DG.Tweening;

public class opningBackgroundController : MonoBehaviour {

	[SerializeField] private GameObject back;
	[SerializeField] private float moveXDif;
	[SerializeField] private float finalbackX;
	[SerializeField] private float finishSec;

	private Vector3 firstPos;

	void Start(){
		firstPos = back.transform.position;
		//backgroundMove();
	}

	void FixedUpdate () {
		transform.Translate(moveXDif,0, 0);
		if (transform.position.x > finalbackX) {
			transform.position = firstPos;
		}
	}
	
	/*
	private Tween backgroundMove(){
		return back.transform.DOMoveX(finalbackX, finishSec).SetLoops(-1, LoopType.Restart);
	}*/
}