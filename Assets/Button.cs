using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {


    void OnMouseEnter()
    {
        GameObject.Find("Config").GetComponent<Config>().config = false;
        Destroy(GameObject.FindGameObjectWithTag("Info"));
        Debug.Log("clicou");
    }
}
