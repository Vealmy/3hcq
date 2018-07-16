using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSceneLoad : MonoBehaviour {

    private GameObject tree;
    private GameObject plants;
    private GameObject homegrid;
    private string treePath= "Prefabs/Tree";
    private string plantsPath = "Prefabs/Plants";
    // private string homegridPath = "Prefabs/HomeGrid";
    //private GameObject wall;                  load墙
   //private string wallPath = "Prefabs/Wall";


    void Awake() {
        tree = Instantiate(Resources.Load(treePath, typeof(GameObject))) as GameObject;
        plants = Instantiate(Resources.Load(plantsPath, typeof(GameObject))) as GameObject;
        //  homegrid = Instantiate(Resources.Load(homegridPath, typeof(GameObject))) as GameObject;
        //  wall = Instantiate(Resources.Load(wallPath, typeof(GameObject))) as GameObject;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
