using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCtr : MonoBehaviour {

    public float movespeed=1f;
    //private Transform player;
	// Use this for initialization
	void Start () {
       
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector3.left * movespeed * Time.deltaTime);
            this.transform.GetComponent<Animator>().SetBool("Iswalk", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector3.right * movespeed * Time.deltaTime);
            this.transform.GetComponent<Animator>().SetBool("Iswalk", true);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.up * movespeed * Time.deltaTime);
            this.transform.GetComponent<Animator>().SetBool("Iswalk", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(Vector3.down * movespeed * Time.deltaTime);
            this.transform.GetComponent<Animator>().SetBool("Iswalk", true);
        }
        else {
            this.transform.GetComponent<Animator>().SetBool("Iswalk", false);
        }
    }

    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        string name = collider.tag;
        Debug.Log(name);
        if (name == "Door") {
            SceneManager.LoadScene(2);
        }
    }

}
