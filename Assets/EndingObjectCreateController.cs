using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingObjectCreateController : MonoBehaviour
{
    
    [SerializeField] public GameObject[] GenerateAnimal;
    [SerializeField] public GameObject startAnimal;
    [SerializeField] public GameObject[] finalAnimal;

    [SerializeField] public float[] animalsMergen;
    private float[] generateAnimatCenter;

    [SerializeField] private EndingController ending;
    
    private GameObject beforeObject;
    
    private parametorController para;

    private float animalposX;
    
    // Start is called before the first frame update
    void Awake()
    {
        para = GameObject.Find("NCMBSettings").GetComponent<parametorController>();
        beforeObject = startAnimal;
        generateAnimatCenter = new float[GenerateAnimal.Length];
        
        animalposX = startAnimal.transform.position.x;

        for(int i = 0; i < GenerateAnimal.Length; i++)
        {
            generateAnimatCenter[i] = GenerateAnimal[i].transform.localScale.y / 2.0f;
            if (i == 0) generateAnimatCenter[i] += 0.5f;//ロバの場合はちょっと下駄をはかせる
        }

        for (int i = 1; i < para.TotalAnimalNum; i++) {
            //動物追加処理
            int generateIndex = i % GenerateAnimal.Length;
            float generatAnimalHight = beforeObject.transform.position.y + generateAnimatCenter[generateIndex];
            //AnimalNum++; i

            GameObject generateObj;
            if (i == para.TotalAnimalNum - 1)
            {
                generateObj = Instantiate(finalAnimal[generateIndex], new Vector3(animalposX + animalsMergen[generateIndex], generatAnimalHight, 0), Quaternion.identity);
            }
            else
            {
                generateObj = Instantiate(GenerateAnimal[generateIndex], new Vector3(animalposX + animalsMergen[generateIndex], generatAnimalHight, 0), Quaternion.identity);

            }
            //generateObj.transform.SetParent (Canvas.transform, false);
            generateObj.transform.localRotation = Quaternion.Euler(0, 0, 180);
            beforeObject = generateObj;
        }

        ending.endObject = beforeObject;



    }

}
