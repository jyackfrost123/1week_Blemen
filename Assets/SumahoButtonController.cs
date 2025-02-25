using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SumahoButtonController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;

    [SerializeField] private parametorController para;
    // Start is called before the first frame update
    void Start()
    {
        para = GameObject.Find("NCMBSettings").GetComponent<parametorController>();
        
        if (para.IsSumaho)
        {
            buttonText.text = "タッチ操作ON中";
        }
        else
        {
            buttonText.text = "タッチ操作OFF中";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PushSumahoButton()
    {
        if (para.IsSumaho)
        {
            para.IsSumaho = false;
            buttonText.text = "タッチ操作OFF中";
        }
        else
        {
            para.IsSumaho = true;
            buttonText.text = "タッチ操作ON中";
        }
    }
}
