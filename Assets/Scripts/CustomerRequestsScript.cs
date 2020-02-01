using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerRequestsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var thisGameLimit = MqCommon.randomMq(3, 8);
        SwipeController.cut_limit = thisGameLimit;
//        GameObject.Find("test").GetComponent<Text>().Text = 
        this.GetComponentInChildren<Text>().text = Convert.ToString(thisGameLimit);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
