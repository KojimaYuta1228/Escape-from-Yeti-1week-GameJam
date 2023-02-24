using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Slider _slider;
    float _curHp;
    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = PlayerStatus._playerHp;//Slider‚ðMax‚É
        _slider.value = _curHp;
       
    }


    void Update()
    {
        _curHp = PlayerStatus._playerHp;
        _slider.value = _curHp;
    }
}
