using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound1 : MonoBehaviour
{
    static public bool _sFireFlag = false;
    static public bool _sWalkFlag = false;
    static public bool _sJumpFlag = false;
    static public bool _sSoriFlag = false;
    static public bool _sEnemyFlag = false;
    static public bool _sObsFlag = false;
    static public bool _sGoalFlag = false;
    void Start()
    {
        SoundMgr.Instance.PlayBGM(BGMSoundData.BGM.Dungeon);
    }

    // Update is called once per frame
    void Update()
    {
        GetFire();
        GetSori();
        GetEnemy();
        GetObs();
        GetJump();
        GetWalk();
        GetGoal();
    }
    void GetFire()
    {
        if (_sFireFlag == true)
        {
            SoundMgr.Instance.PlaySE(SESoundData.SE.GetFire);
            _sFireFlag = false;
        }
    }
    void GetSori()
    {
        if(_sSoriFlag == true)
        {
            SoundMgr.Instance.PlaySE(SESoundData.SE.GetSori);
            _sSoriFlag = false;
        }
    }
    void GetObs()
    {
        if(_sObsFlag == true)
        {
            SoundMgr.Instance.PlaySE(SESoundData.SE.Damage);
            _sObsFlag = false;
        }
    }
    void GetWalk()
    {
        if(_sWalkFlag == true)
        {
            SoundMgr.Instance.PlaySE(SESoundData.SE.Walk);
            _sWalkFlag = false;
        }
    }
    void GetJump()
    {
        if(_sJumpFlag == true)
        {
            SoundMgr.Instance.PlaySE(SESoundData.SE.Jump);
            _sJumpFlag = false;
        }
        
    }
    void GetGoal()
    {
        if(_sGoalFlag == true)
        {
            SoundMgr.Instance.PlaySE(SESoundData.SE.Goal);
            _sGoalFlag = false;
        }
    }
    void GetEnemy()
    {
        if(_sEnemyFlag == true)
        {
            SoundMgr.Instance.PlaySE(SESoundData.SE.Enemy);
            _sEnemyFlag = false;
        }
    }
}
