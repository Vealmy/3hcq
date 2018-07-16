using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StartScenseCtr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void onStartBtnClick() {
        SceneManager.LoadScene(1);
    }
    public void onBtn2Click()
    {
        SceneManager.LoadScene(1);
    }
    public void onExitClick() {
        Application.Quit();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
