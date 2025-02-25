using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    [SerializeField] public GameObject[] GenerateAnimal;
    [SerializeField] public GameObject startAnimal;

    [SerializeField] public float[] animalsMergen;
    
    [field: SerializeField] public int AnimalNum { get; set; }
    [field: SerializeField] public float AnimalTotalHight { get; set; }

    [SerializeField] private UIController ui;

    [SerializeField] private float animalposX;
    [SerializeField] private float animalposY;
    [SerializeField] private float animalHight;
    [SerializeField] private float robaMargen;

    [SerializeField] private float cameraMoveDuration = 0.1f;

    private GameObject Canvas;
    private GameObject camera;

    private float[] generateAnimatCenter;

    private GameObject beforeObject;
    private bool IsGenerate { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        camera = GameObject.Find("Main Camera");

        ui = GameObject.Find("Canvas").GetComponent<UIController>();
        
        //動物の高さとか初期位置とか
        //RectTransform startAnimalInfo = startAnimal.GetComponent<RectTransform>();
        animalposX = startAnimal.transform.position.x;
        animalposY = startAnimal.transform.position.y;
        animalHight = startAnimal.transform.localScale.y;//hight
        
        // 初期化
        AnimalNum = 0;
        IsGenerate = false;
        beforeObject = startAnimal;
        generateAnimatCenter = new float[GenerateAnimal.Length];
        for(int i = 0; i < GenerateAnimal.Length; i++)
        {
            generateAnimatCenter[i] = GenerateAnimal[i].transform.localScale.y / 2.0f;
            if (i == 0) generateAnimatCenter[i] += robaMargen;//ロバの場合はちょっと下駄をはかせる
        }
    }
    
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space) && !IsGenerate)
         {
             IsGenerate = true;
         }
     }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsGenerate && ui.isGameStart)
        {
            //動物追加処理
            int generateIndex = AnimalNum % GenerateAnimal.Length;
            float generatAnimalHight = beforeObject.transform.position.y + generateAnimatCenter[generateIndex];
            AnimalNum++;
            AnimalTotalHight += generateAnimatCenter[generateIndex] * 10.0f;//スコアの上り幅が面白くないので数倍に
            
            GameObject generateObj = Instantiate(GenerateAnimal[generateIndex], new Vector3(animalposX + animalsMergen[generateIndex], generatAnimalHight, 0), Quaternion.identity);
            //generateObj.transform.SetParent (Canvas.transform, false);
            generateObj.transform.localRotation = Quaternion.Euler(0, 0, 180);
            beforeObject = generateObj;
            
            //カメラ追従
            camera.transform.DOMoveY(camera.transform.position.y + generateAnimatCenter[generateIndex], cameraMoveDuration);

            IsGenerate = false;
        }
    }

    public void getFirstAnimalTotalHight()
    {
        AnimalTotalHight += generateAnimatCenter[0] * 10.0f;//最初のロバの分を足す
    }

    public void sumahoSpaceRenda()
    {
        if (!IsGenerate)
        {
            IsGenerate = true;
        }
    }
}
