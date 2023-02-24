using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCon : MonoBehaviour
{
    static public Rigidbody2D _rb2;
    static public bool _enemyMoveFlag = true;
    float _timer =0;
    public GameObject _target;

    void Start()
    {
        _timer = 0;
        _rb2 = GetComponent<Rigidbody2D>();
        _enemyMoveFlag = true;
        
    }

   
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > 3)
        {
            EnemyMove();
        }
        
        
    }
   public void EnemyMove()
    {
        if(_enemyMoveFlag ==true) transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, 1.8f * Time.deltaTime);
        if (_enemyMoveFlag == false) _rb2.velocity = new Vector2(-3.0f, PlayerMove._rb.gameObject.transform.position.y);
    }
}
