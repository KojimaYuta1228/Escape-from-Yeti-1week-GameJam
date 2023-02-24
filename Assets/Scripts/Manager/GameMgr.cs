using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    //g�Q�[�����ł̏��
    public enum PlayStatus
    {
        NONE,
        READY,
        PLAY,
        FINISH,
    }
    public PlayStatus _curState = PlayStatus.NONE;//���݂̏��
    int _cntStartTime = 3;//�J�E���g�_�E���^�C��
    [SerializeField] Text _cntTxt = null;//�J�E���g�_�E���e�L�X�g
    [SerializeField] Text _timerTxt = null;
    float _curCntDown = 0;//�J�E���g�_�E���̌��ݒl
    float _timer = 0;//�Q�[���̊J�n����
    void Start()
    {
        CountDownStart();
    }

    void Update()
    {
        _timerTxt.text = "Time : 000.0 s";
        // �X�e�[�g��Ready�̂Ƃ�.
        if (_curState == PlayStatus.READY)
        {
            // ���Ԃ������Ă���.
            _curCntDown -= Time.deltaTime;

            int intNum = 0;
            // �J�E���g�_�E����.
            if (_curCntDown <= (float)_cntStartTime && _curCntDown > 0)
            {
                // int(����)��.
                intNum = (int)Mathf.Ceil(_curCntDown);
                _cntTxt.text = intNum.ToString();
            }
            else if (_curCntDown <= 0)
            {
                // �J�n.
                StartPlay();
                intNum = 0;
                _cntTxt.text = "Start!!";

                // Start�\�����������ď���.
                StartCoroutine(WaitErase());
            }
        }
        // �X�e�[�g��Play�̂Ƃ�.
        else if (_curState == PlayStatus.PLAY)
        {
            _timer += Time.deltaTime;
            _timerTxt.text = "Time : " + _timer.ToString("000.0") + " s";
        }
        else
        {
            _timer = 0;
            _timerTxt.text = "Time : 000.0 s";
        }
    }

    // -------------------------------------------------------
    /// <summary>
    /// �J�E���g�_�E���X�^�[�g.
    /// </summary>
    // -------------------------------------------------------
    void CountDownStart()
    {
        _curCntDown = (float)_cntStartTime;
        SetPlayState(PlayStatus.READY);
        _cntTxt.gameObject.SetActive(true);
    }

    // -------------------------------------------------------
    /// <summary>
    /// �Q�[���X�^�[�g.
    /// </summary>
    // -------------------------------------------------------
    void StartPlay()
    {
        Debug.Log("Start!!!");
        SetPlayState(PlayStatus.PLAY);
    }

    // -------------------------------------------------------
    /// <summary>
    /// �����҂��Ă���Start�\��������.
    /// </summary>
    // -------------------------------------------------------
    IEnumerator WaitErase()
    {
        yield return new WaitForSeconds(2f);
        _cntTxt.gameObject.SetActive(false);
    }

    // -------------------------------------------------------
    /// <summary>
    /// ���݂̃X�e�[�g�̐ݒ�.
    /// </summary>
    /// <param name="state"> �ݒ肷��X�e�[�g. </param>
    // -------------------------------------------------------
    void SetPlayState(PlayStatus state)
    {
        _curState = state;
    }

}
