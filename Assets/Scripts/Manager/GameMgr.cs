using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{
    //gゲーム内での状態
    public enum PlayStatus
    {
        NONE,
        READY,
        PLAY,
        FINISH,
    }
    public PlayStatus _curState = PlayStatus.NONE;//現在の状態
    int _cntStartTime = 3;//カウントダウンタイム
    [SerializeField] Text _cntTxt = null;//カウントダウンテキスト
    [SerializeField] Text _timerTxt = null;
    float _curCntDown = 0;//カウントダウンの現在値
    float _timer = 0;//ゲームの開始時間
    void Start()
    {
        CountDownStart();
    }

    void Update()
    {
        _timerTxt.text = "Time : 000.0 s";
        // ステートがReadyのとき.
        if (_curState == PlayStatus.READY)
        {
            // 時間を引いていく.
            _curCntDown -= Time.deltaTime;

            int intNum = 0;
            // カウントダウン中.
            if (_curCntDown <= (float)_cntStartTime && _curCntDown > 0)
            {
                // int(整数)に.
                intNum = (int)Mathf.Ceil(_curCntDown);
                _cntTxt.text = intNum.ToString();
            }
            else if (_curCntDown <= 0)
            {
                // 開始.
                StartPlay();
                intNum = 0;
                _cntTxt.text = "Start!!";

                // Start表示を少しして消す.
                StartCoroutine(WaitErase());
            }
        }
        // ステートがPlayのとき.
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
    /// カウントダウンスタート.
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
    /// ゲームスタート.
    /// </summary>
    // -------------------------------------------------------
    void StartPlay()
    {
        Debug.Log("Start!!!");
        SetPlayState(PlayStatus.PLAY);
    }

    // -------------------------------------------------------
    /// <summary>
    /// 少し待ってからStart表示を消す.
    /// </summary>
    // -------------------------------------------------------
    IEnumerator WaitErase()
    {
        yield return new WaitForSeconds(2f);
        _cntTxt.gameObject.SetActive(false);
    }

    // -------------------------------------------------------
    /// <summary>
    /// 現在のステートの設定.
    /// </summary>
    /// <param name="state"> 設定するステート. </param>
    // -------------------------------------------------------
    void SetPlayState(PlayStatus state)
    {
        _curState = state;
    }

}
