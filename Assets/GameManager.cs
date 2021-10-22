using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float Level(int score) {
        int basicSpeed=-3;
        int upSpeed=(score*-1)/30;
        if (upSpeed<-5) { upSpeed=-5; };

        return basicSpeed + upSpeed;
    }
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
