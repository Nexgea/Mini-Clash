using UnityEngine;
using System.Collections;
using  UnityEngine.Analytics;
using System.Collections.Generic;
public class UnityAnalytics : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Analytics.CustomEvent("CodeSend", new Dictionary<string, object>
  {
    { "code", "DistributorCode" }
  });
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
