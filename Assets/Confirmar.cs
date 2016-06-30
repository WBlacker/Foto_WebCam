using UnityEngine;
using System.Collections;

public class Confirmar : MonoBehaviour {

    public void SalvaSim()
    {
        Debug.Log("Sim");
        GameObject.Find("WebCam").GetComponent<WebCam>().SalvarFoto();
        GameObject.Find("WebCam").GetComponent<WebCam>().ValorInicial();
        Destroy(GameObject.FindWithTag("Confir"));


    }

    public void SalvaNao()
    {
        Debug.Log("Nao");
        GameObject.Find("WebCam").GetComponent<WebCam>().ValorInicial();
        Destroy(GameObject.FindWithTag("Confir"));
    }
}
