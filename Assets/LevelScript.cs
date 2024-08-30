using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelScript : MonoBehaviour
{

    public static LevelScript instance; 
    public GameObject KnifePref;

    public GameObject LiveKnife;
    public List<GameObject> LiveKnifeList;
    public Knife knife;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        StartCoroutine(CreateKnife());
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) {
        //    Debug.Log("adsasdasda");
        //    if (LiveKnife) {
               
        //        ThrowKnife();
                
        //    }
        
        
        //}
    }
    //void ThrowKnife()
    //{
    //    LiveKnife.GetComponent<Rigidbody2D>().isKinematic = false;
    //    LiveKnife.transform.DORotate(new Vector3(0f, 0f, 360f), 20f, RotateMode.FastBeyond360)
    //       .SetLoops(-1, LoopType.Restart)
    //       .SetRelative()
    //       .SetEase(Ease.Linear);
    //    LiveKnife.transform.DOMoveY(10, 1).SetEase(Ease.Linear).OnComplete(() => {
    //        if (LiveKnifeList.Count > 0) {

    //            Destroy(LiveKnifeList[0]);
    //            StartCoroutine(CreateKnife());

    //        }
        
        
    //    });

    //}
    public IEnumerator  CreateKnife() {

        yield return new WaitForSeconds(0.2f);
      
             
        Instantiate(KnifePref);
        // knife=LiveKnife.GetComponent<Knife>();
        //LiveKnifeList.Add(LiveKnife);
       // knife.StartScalling();
       // LiveKnife.transform.DOScale(Vector3.one,0.1f).SetEase(Ease.OutSine).OnComplete(()=> knife.StartScalling());
    }
}
