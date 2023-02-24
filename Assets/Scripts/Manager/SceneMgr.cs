using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{
    static public bool _moveSceneFlag = true;
    static public bool _movePlay2SceneFlag = true;
    static public bool _movePlay3SceneFlag = true;
    static public bool _movePlayGameOverSceneFlag = true;
    static public bool _moveTitleSceneFlag = true;
    private float _elapsed;
    private float _interbal = 2.0f;

    
    void Start()
    {
        
    }

    
    void Update()
    {
       
        if(_moveSceneFlag == false)
        {
            _elapsed += Time.deltaTime;
            if(_elapsed > _interbal)
            {
                MoveResultScene();
                _moveSceneFlag = true;
            }
        }
        if (_movePlay2SceneFlag == false)
        {
            MovePlay2Scene();
            _movePlay2SceneFlag=true;
        }
        if (_movePlay3SceneFlag == false)
        {
            MovePlay3Scene();
            _movePlay3SceneFlag=true;
        }
        if (_movePlayGameOverSceneFlag ==false)
        {
           
            _movePlayGameOverSceneFlag=true;
            MoveGameOverScene();
        }
        if (_moveTitleSceneFlag == false)
        {
            _moveTitleSceneFlag=true;
            MoveTitleScene();
        }
    }
   
    public void MoveExplainScene()
    {
        SceneManager.LoadScene("ExplainScene");
    }
    public void MoveStartScene()
    { 
        SceneManager.LoadScene("PlayScene");
    }
    public void MoveGameScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("TitleScene");
    
    }
    public void MoveTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void MoveResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
    public void MovePlay2Scene()
    {
        SceneManager.LoadScene("Play2Scene");
    }
    public void MovePlay3Scene()
    {
        SceneManager.LoadScene("Play3Scene");
    }
    public void MoveGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }

 
//　ゲーム終了ボタンを押したら実行する
public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
		Application.OpenURL("http://www.yahoo.co.jp/");
#else
		Application.Quit();
#endif
    }

}
