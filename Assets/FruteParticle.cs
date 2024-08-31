using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruteParticle : MonoBehaviour
{
    public List<ParticleSystem> FruteParticalList;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayParticle(Color color) {
        for (int i = 0; i < FruteParticalList.Count; i++)
        {
            var main = FruteParticalList[i].main;
             main.startColor = color;
            FruteParticalList[i].Play();
        }

    }
}
