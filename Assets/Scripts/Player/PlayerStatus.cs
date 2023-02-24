using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    [Header("PlayerHP"), SerializeField]public static float _playerHp = 20.0f;
    [Header("HP������"), SerializeField] private float _decreaseHp = 1.0f;
    [Header("HP�񕜗�"), SerializeField] private float _helthHp = 1.0f;
    [Header("��ԕω�����1"), SerializeField]public float _stateTime;
    [Header("��ԕω����E����1"), SerializeField] public float _stateLimitTime =2.0f;
    [Header("�X�s�[�hUP�A�C�e��"), SerializeField]float _speedUpItem = 1.2f;
    [Header("�m�b�N�o�b�N��"), SerializeField] float _knockBackPower = 4.0f;
    private float _decreaseInterval = 1.0f;//Hp�����p�C���^�[�o��
    private float _decreaseElapsed =0;//Hp�����p�o�ߎ���
    private float _helthInterval = 0.5f;//Hp�񕜗p�C���^�[�o��
    private float _helthElapsed = 0;//Hp�񕜗p�o�ߎ���
    private bool _hpFlag = false;
    static public bool _statusFlag = false;
    private float _reMoveTime = 0;
    float _cntStatus=0;
   


    void Start()
    {
        _cntStatus = 0;
        _playerHp = 20.0f;
    }


    void Update()
    {
       
       _cntStatus += Time.deltaTime;
        if(_cntStatus > 3.0f)
        {
            if (!_hpFlag)
            {
                HpDecrease();
            }
            if (_statusFlag == true)
            {
                _stateTime += Time.deltaTime;
                if (_stateTime > _stateLimitTime)
                {
                    PlayerMove._rb.velocity = Vector2.zero;
                    _stateTime = 0;
                    _statusFlag = false;
                }
            }
            if (_reMoveTime > 5 && Input.GetKeyDown(KeyCode.Space))
            {
                PlayerMove._rb.velocity = new Vector2(PlayerMove._speed, 0);
            }
            if (_hpFlag)
            {
                _reMoveTime += Time.deltaTime;

                //���X��Hp����
                _helthElapsed += Time.deltaTime;
                if (_helthElapsed > _helthInterval)
                {
                    if (_playerHp < 20)
                    {
                        _playerHp += _helthHp;
                        _helthElapsed = 0;
                    }
                }
            }
        }
        if(_playerHp < 0)SceneMgr._movePlayGameOverSceneFlag = false;
       
    }
    private void HpDecrease()
    {
       
       //���X��Hp������
        _decreaseElapsed += Time.deltaTime;
        if( _decreaseElapsed > _decreaseInterval)
        {
            _playerHp -= _decreaseHp;
            _decreaseElapsed = 0;   
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("_speedUpItem"))
        {
            sound1._sSoriFlag = true;
            Destroy(collision.gameObject);
            _statusFlag = true;
            PlayerMove._speed *= _speedUpItem;

        }
        if (collision.gameObject.CompareTag("Item"))
        {
            sound1._sFireFlag = true;
            PlayerMove._moveFlag = false;

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            sound1._sEnemyFlag = true;
            SceneMgr._movePlayGameOverSceneFlag = false;
          
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            sound1._sObsFlag = true;
            PlayerMove._knockbackFlag = true;
            PlayerMove._landingFlag = true;
            Vector2 force = new Vector2(-_knockBackPower, 4.0f);
            PlayerMove._rb.AddForce(force, ForceMode2D.Impulse);
            Destroy(collision.gameObject);
        
        }
       
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            _hpFlag = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
           
            _hpFlag = false;
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            EnemyCon._enemyMoveFlag =false;
            sound1._sGoalFlag = true;
            SceneMgr._moveSceneFlag = false;
            
        }
        if (collision.gameObject.CompareTag("CheckPoint1"))
        {
            sound1._sGoalFlag = true;
            SceneMgr._movePlay2SceneFlag = false;
        }
        if (collision.gameObject.CompareTag("CheckPoint2"))
        {
            sound1._sGoalFlag = true;
            SceneMgr._movePlay3SceneFlag = false;
        }
    }

}
