using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 注释掉，改用NGUI做
/// </summary>
public class Scenemanager : MonoBehaviour {

    private GameObject bagpackUI;
    private string bagPath = "Prefabs/BG";
    private bool haveBuild = false;
    private bool hasBuild = false;
    private GameObject playerUI;
    private string playUiPath = "Prefabs/PlayerUI";
    private bool haveBuildP = false;
    private bool hasBuildP = false;
  //  public GameObject itemDes;

    // Use this for initialization
    void Start () {
		
	}

    public void OnBagBtnClick() {
        if (!haveBuild)
        {
            if (!hasBuild)
            {
                bagpackUI = Instantiate(Resources.Load(bagPath, typeof(GameObject))) as GameObject;
                bagpackUI.transform.parent = GameObject.Find("Canvas").gameObject.transform;
                bagpackUI.GetComponent<RectTransform>().localPosition= new Vector3(180, 0, 0);
                haveBuild = true;
                hasBuild = true;
            }
            else {
                bagpackUI.SetActive(true);
                haveBuild = true;
            }
        }
        else {
            bagpackUI.SetActive(false);
            haveBuild = false;
        }
    }
    public void OnPlayerBtnClick() {
        if (!haveBuildP)
        {
            if (!hasBuildP)
            {
                playerUI= Instantiate(Resources.Load(playUiPath, typeof(GameObject))) as GameObject;
                playerUI.transform.parent = GameObject.Find("Canvas").gameObject.transform;
                playerUI.GetComponent<RectTransform>().localPosition = new Vector3(-180, 0, 0);
				this.transform.GetComponent<PlayerManager>().Load() ; //Debug.Log("load");
                haveBuildP = true;
                hasBuildP = true;
            }
            else
            {
                playerUI.SetActive(true);
                haveBuildP = true;
            }
        }
        else
        {
            playerUI.SetActive(false);
            haveBuildP = false;
        }
    }
}

