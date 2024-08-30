using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
   private Rigidbody2D rb;
    public float throwForce;

    private void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            ThrowKnife(); 
        }

    }

    void ThrowKnife() 
    {
        transform.DORotate(new Vector3(0f, 0f, 360f), 20f, RotateMode.FastBeyond360)
           .SetLoops(-1, LoopType.Restart)
           .SetRelative()
           .SetEase(Ease.Linear);
        rb.AddForce(transform.up * throwForce, ForceMode2D.Impulse);
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fruit")
        {
            Destroy(collision.gameObject);
        }
    }
}
