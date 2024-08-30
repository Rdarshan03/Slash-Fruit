using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(2f, 2f, 2f); // Target scale
    public float duration = 1f; // Duration for the scale animation

    private Vector3 originalScale;
    private Tween scaleTween;
    public float rotationSpeed = 100f;
    public bool isRot;
    float rotationAmount;

    public bool isMove=false;
    float newY;
    void Start()
    {

        
    }
    private void FixedUpdate()
    {
        //if (isRot) {
        //    rotationAmount = rotationSpeed * Time.deltaTime;
        //    transform.Rotate(Vector3.forward, rotationAmount);

        //}
        //if (transform.position.y > 5.20f) {
        //    Destroy(transform.gameObject);
        //}
        if (Input.GetMouseButtonDown(0)) {

            isMove=true;
        }
            if (isMove) {

          

            // Update the GameObject's position
            transform.position = new Vector3(transform.position.x, transform.position.y+0.1f, transform.position.z);
        }
    }

    //public void StopScaling()
    //{
    //    if (scaleTween != null)
    //    {
    //        scaleTween.Kill(); // Stop the tween
    //    }
    //    transform.localScale = originalScale;
    //}
    //public void StartScalling() {

    //    originalScale = transform.localScale;


    //    scaleTween = transform.DOScale(targetScale, duration)
    //        .SetEase(Ease.InOutSine)
    //        .SetLoops(-1, LoopType.Yoyo);
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "line")
        {
            StartCoroutine(LevelScript.instance.CreateKnife());
            Destroy(gameObject);

        }
    }
}
