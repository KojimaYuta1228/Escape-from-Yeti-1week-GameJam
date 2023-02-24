using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    [SerializeField]public TextMeshProUGUI _timerTxt;
   

    static public float _time = 0;
    float _cntTimer;

    void Start()
    {
        _time = 0;
        _cntTimer = 0;
    }

    
    void Update()
    {
        _cntTimer += Time.deltaTime;
        if(_cntTimer > 3.0f)
        {
            _time += Time.deltaTime;
          
        }
        GetComponent<TextMeshProUGUI>().text = _time.ToString("f2");

    }
   
}
