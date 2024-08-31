using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public Color myColor;
    public GameObject FruitPartPref;
    public Sprite FruitPart_1;
    public Sprite FruitPart_2;
    Collider2D MyCollider;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        MyCollider = GetComponent<Collider2D>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }
    public void startFruitAnim() {

     
        MyCollider.enabled = false;
        spriteRenderer.enabled = false;
       

        GameObject Part1=Instantiate(FruitPartPref);
        Part1.GetComponent<SpriteRenderer>().sprite = FruitPart_1;
        Part1.transform.localScale=transform.localScale;
        Part1.transform.position=transform.position;
        Part1.transform.DORotate(new Vector3(0, 0, 360), 0.7f, RotateMode.FastBeyond360);
        Part1.transform.DOMoveX(Part1.transform.position.x - 1f, 0.4f);
        Part1.transform.DOMoveY(Part1.transform.position.y + 1.5f, 0.4f).OnComplete(() =>
        {

            Part1.transform.DOMove(LevelScript.instance.FruteAnimStoppoint.position, 0.3f).OnComplete(() => Part1.transform.DOScale(Vector3.zero, 0.5f));
           
        });

        GameObject Part2 = Instantiate(FruitPartPref);

        Part2.GetComponent<SpriteRenderer>().sprite = FruitPart_2;
        Part2.transform.localScale = transform.localScale;
        Part2.transform.position = transform.position;
        Part2.transform.DORotate(new Vector3(0, 0, -360), 0.7f,RotateMode.FastBeyond360);
        Part2.transform.DOMoveX(Part2.transform.position.x + 1f, 0.4f);
        Part2.transform.DOMoveY(Part2.transform.position.y +1.5f, 0.5f).OnComplete(() =>
        {

            Part2.transform.DOMove(LevelScript.instance.FruteAnimStoppoint.position, 0.5f).OnComplete(() => Part2.transform.DOScale(Vector3.zero, 0.5f));
            LevelScript.instance.CreateFill(myColor);
        });
    }
}

