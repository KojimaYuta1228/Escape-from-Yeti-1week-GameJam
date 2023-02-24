using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBer : MonoBehaviour
{
    [Header("Stsrt�n�_��X"), SerializeField] public static float _startPosX;//�X�^�[�g�n�_(Player�̍ŏ���Pos)��Pos�������Ă���
    [Header("Goal�n�_��X"), SerializeField] public static float _goalPosX;//�S�[���n�_��Pos�������Ă���
  
    public Slider _slider;
    void Start()
    {
        _slider = GetComponent<Slider>();
        _startPosX = GameObject.Find("StartGameObject").transform.position.x;
        _goalPosX = GameObject.Find("CheckPoint1").transform.position.x;
        float _sum = _goalPosX - _startPosX;
        _slider.maxValue = _sum;//stage�S�̂̒���
    }

    
    void Update()
    {
        
        var playerBer = GameObject.Find("Player");
        _slider.value = playerBer.transform.position.x - _startPosX;
    }
}
