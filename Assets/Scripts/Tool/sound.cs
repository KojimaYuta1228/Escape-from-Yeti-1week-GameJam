using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    
    void Start()
    {
        SoundMgr.Instance.PlayBGM(BGMSoundData.BGM.Title);
    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundMgr.Instance.PlaySE(SESoundData.SE.Select);
        }
    }
}
