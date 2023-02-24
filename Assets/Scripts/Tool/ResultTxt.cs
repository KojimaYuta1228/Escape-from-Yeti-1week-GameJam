using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultTxt : MonoBehaviour
{
    public TextMeshProUGUI _resultTxt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text= "ClearTime :"+Timer._time.ToString("f2");
    }
}
