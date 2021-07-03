using UnityEngine;
using System.Collections;
 
public class ConsoleTest : MonoBehaviour {
 
	private float nowTime = 0f;
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		nowTime += Time.deltaTime;
 
		if (nowTime >= 1f) {
			Debug.Log ("ConsoleTest");
			nowTime = 0f;
		}
	}
}