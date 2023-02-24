using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static Rigidbody2D _rb;
    public static float _stanTimer;
    public static bool _moveFlag = true;
    public static bool _knockbackFlag = false;
    public static bool _landingFlag = false;
    float _cntStart = 3;
    [Header("�ړ����x"), SerializeField] public static float _speed = 2.0f;
    [Header("�W�����v��"), SerializeField]private float _jumpPower = 5.0f;
    [Header("�W�����v��"), SerializeField]private int _jumpCount = 0;
    [Header("�W�����v���E��"), SerializeField] private int _jumpLimit = 3;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _cntStart = 0;
        _speed = 2.0f;
        _jumpPower = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _cntStart += Time.deltaTime;
        if(_cntStart > 3.0f)
        {
            Move();
        }
       
    }
    private void Move()
    {
        if (_moveFlag && !_knockbackFlag && !_landingFlag)
        {
            _rb.velocity = new Vector2(_speed, _rb.velocity.y);
            Vector2 force = Vector2.up * _jumpPower;
            
        
            if (Input.GetMouseButtonDown(0) && _jumpCount < _jumpLimit)
            {
                sound1._sJumpFlag = true;
                _rb.velocity = new Vector2(_speed, _jumpPower);
                _jumpCount++;
            }
        }
        else if(!_moveFlag)
        {
            if (_jumpCount != 0 )
            {
                _rb.velocity = new Vector2(_speed, _rb.velocity.y);
            }
            else
            {
                _rb.velocity = Vector2.zero;
                if (Input.GetMouseButtonDown(0))
                {
                    _moveFlag = true;
                }
            }
        }
        else if (_knockbackFlag)
        {
            
            _jumpCount = _jumpLimit;
            if(_landingFlag == true )
            {
                _knockbackFlag = false;               
            }

        }
        if (Input.GetMouseButtonDown(2))
        {
            SceneMgr._moveTitleSceneFlag = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //----------------Tag�Ŕ���----------------//
        //Stage�Ƃ̔���
        if (collision.gameObject.CompareTag("Stage"))
        {
            _jumpCount = 0;
            if (_landingFlag ) 
            {
                sound1._sWalkFlag = true;
                _rb.velocity = Vector2.zero;
                _landingFlag = false;

            }
            
        
        }
    }
}
