using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 注释掉，改用NGUI做
/// </summary>
public class DisplayIcon : MonoBehaviour {
    private GameObject UIIcon;
    // Use this for initialization
    void Start () {
       
    }
    void OnGUI() {

       // UIIcon = Instantiate(Resources.Load("Prefabs/UIIcon1_0", typeof(GameObject))) as GameObject;
        //UIIcon.transform.parent = GameObject.Find("Canvas/BagPack/Grid1").gameObject.transform;///BagPack/Grid1"
    }
    // Update is called once per frame
    void Update () {
		
	}
}
