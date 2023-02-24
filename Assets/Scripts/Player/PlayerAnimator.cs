using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]Animator _anim;
    Animation anm;//アニメーションコンポーネント
   
    
    void Start()
    {
        anm = GetComponent<Animation>();
      
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _anim.SetTrigger("TuchObstacle");
        }
    }
}
