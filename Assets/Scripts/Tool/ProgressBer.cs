using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBer : MonoBehaviour
{
    [Header("Stsrt地点のX"), SerializeField] public static float _startPosX;//スタート地点(Playerの最初のPos)のPosを持ってくる
    [Header("Goal地点のX"), SerializeField] public static float _goalPosX;//ゴール地点のPosを持ってくる
  
    public Slider _slider;
    void Start()
    {
        _slider = GetComponent<Slider>();
        _startPosX = GameObject.Find("StartGameObject").transform.position.x;
        _goalPosX = GameObject.Find("CheckPoint1").transform.position.x;
        float _sum = _goalPosX - _startPosX;
        _slider.maxValue = _sum;//stage全体の長さ
    }

    
    void Update()
    {
        
        var playerBer = GameObject.Find("Player");
        _slider.value = playerBer.transform.position.x - _startPosX;
    }
}
