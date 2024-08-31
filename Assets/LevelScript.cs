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

    public Transform throwPoint; 
    public Transform FruteAnimStoppoint; 



    public Vector3 targetScale = new Vector3(2f, 2f, 1f);
    public float duration = 1f;
    private Tween scaleTween;
    private void Awake()
    {
        instance=this;
    }
    private void Start()
    {
        // animator.SetTrigger("create");
        InitializeAnimation();
    }
    private void Update()
    {
        // Check for input to throw the knife (e.g., pressing the space bar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowKnife();
        }
    }
    public void InitializeAnimation()
    {
        // Optionally stop any existing tween
        scaleTween?.Kill();

        // Start a new scaling animation
        knifeImageAnim.transform.localScale = Vector3.zero;
        scaleTween = knifeImageAnim.transform.DOScale(targetScale, duration)
            .SetEase(Ease.InOutBounce) // Customize easing
            .OnComplete(OnAnimationComplete);
    }
    private void ThrowKnife()
    {
        if (knifePrefab && throwPoint)
        {
            // Instantiate the knife at the throw point
            InitializeAnimation();
            GameObject knife = Instantiate(knifePrefab, throwPoint.position, throwPoint.rotation);

            // Get the Knife script and Rigidbody2D component
            Knife knifeScript = knife.GetComponent<Knife>();
            Rigidbody2D rb = knife.GetComponent<Rigidbody2D>();
          
            if (rb)
            {
                // Set the knife's velocity based on throw direction and speed
                rb.velocity = throwPoint.up * knifeScript.speed;

                // Optionally, enable rotation
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

    private void OnAnimationComplete()
    {
        Debug.Log("Scaling animation completed!");
    }
}
