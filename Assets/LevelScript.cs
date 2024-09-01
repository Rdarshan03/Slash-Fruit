using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public static LevelScript instance;

    public GameObject knifePrefab;
    public GameObject knifeImageAnim;
    public GameObject FillPref;
    public GameObject FillParent;
    public List<SpriteFillVerticalWithColor> FillPrefList;
    public GameObject ParticlePref;
    public Transform throwPoint; 
    public Transform FruteAnimStoppoint1;
    public Transform FruteAnimStoppoint2;
    public int WinCount;


    public Vector3 targetScale = new Vector3(2f, 2f, 1f);
    public float duration = 1f;
    private Tween scaleTween;
    public GameObject Glass;
    private void Awake()
    {
        instance=this;
    }
    private void Start()
    {
      
        InitializeAnimation();
    }
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowKnife();
        }
    }
    public void InitializeAnimation()
    {
      
        scaleTween?.Kill();
        knifeImageAnim.transform.localScale = Vector3.zero;
        scaleTween = knifeImageAnim.transform.DOScale(targetScale, duration)
            .SetEase(Ease.InOutBounce)
            .OnComplete(()=>{ });
    }
    private void ThrowKnife()
    {
        if (knifePrefab && throwPoint)
        {
         
            InitializeAnimation();
            GameObject knife = Instantiate(knifePrefab, throwPoint.position, throwPoint.rotation);
            Knife knifeScript = knife.GetComponent<Knife>();
            Rigidbody2D rb = knife.GetComponent<Rigidbody2D>();
          
            if (rb)
            {
               
                rb.velocity = throwPoint.up * knifeScript.speed;
                knifeScript.knifeRot = true;
            }
        }
    }

    public void CreateFill(Color color) {

        GameObject fill = Instantiate(FillPref, FillParent.transform);
        SpriteFillVerticalWithColor fillEffectController = fill.GetComponent<SpriteFillVerticalWithColor>();
        fillEffectController.fillColor = color;
        if (FillPrefList.Count == 0)
        {
            fillEffectController.fillAmount = 0.1f;
        }
        else
        {
            fillEffectController.spriteRenderer.sortingOrder = FillPrefList[FillPrefList.Count - 1].spriteRenderer.sortingOrder - 1;
            fillEffectController.fillAmount = FillPrefList[FillPrefList.Count - 1].fillAmount + 0.1f;

        }
        FillPrefList.Add(fillEffectController);



    }
    public void StopAnimation()
    {
        if (scaleTween != null)
        {
            scaleTween.Kill();
        }
    }

    public void LevelWin() {

        StartGlassAnim();
        Debug.Log("Winn");
    }
    public void StartGlassAnim() {
        StopAnimation();
        knifeImageAnim.transform.DOScale(Vector3.zero, duration).SetDelay(2f);
        Glass.transform.DOMoveX(Glass.transform.position.x, 1).SetDelay(2f).OnComplete(() => {
            for (int i = 0; i < FillPrefList.Count; i++)
            {
                FillPrefList[i].speed = 1.5f;
                FillPrefList[i].fillAmount = 0f;
                FillPrefList[i].waveSpeed = 0f;
                FillPrefList[i].waveFrequency = 0f;
                FillPrefList[i].waveAmplitude = 0f;
            }
            Glass.transform.DOMoveX(5f, 1).SetDelay(5f);
           

        });


    }
}
