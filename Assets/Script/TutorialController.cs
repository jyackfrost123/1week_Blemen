using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject[] tutorialAnimal;
    [SerializeField] private GameObject[] animalSE;

    [SerializeField] private int animalNum;
    private bool isChange = false;
    // Start is called before the first frame update
    void Start()
    {
        animalNum = 0;

        for (int i = 0; i < tutorialAnimal.Length; i++)
        {
            if(i != 0) tutorialAnimal[i].SetActive(false);
            else tutorialAnimal[i].SetActive(true);//0の時のみ
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isChange)
        {
            isChange = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isChange)
        {
            animalNum++;
            if (animalNum % (tutorialAnimal.Length + 1) == tutorialAnimal.Length)
            {
                foreach (GameObject obj in tutorialAnimal)
                {
                    obj.SetActive(false);
                }
            }
            else
            {
                tutorialAnimal[animalNum % (tutorialAnimal.Length + 1)].SetActive(true);
                Instantiate(animalSE[animalNum % (tutorialAnimal.Length + 1)]);
            }

            isChange = false;
        }
    }
}
