using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Confirmar : MonoBehaviour {

    public void SalvaSim()
    {
        Debug.Log("Sim");
        GameObject.Find("WebCam").GetComponent<WebCam>().SalvarFoto();
        GameObject.Find("WebCam").GetComponent<WebCam>().ValorInicial();
		GameObject.Find("Config").GetComponent<Button>().interactable = true;
		GameObject.Find ("CanvasIntro").GetComponent<VariavelSave> ().SalvarVariavel ();
        Destroy(GameObject.FindWithTag("Confir"));


    }

    public void SalvaNao()
    {
        Debug.Log("Nao");
        GameObject.Find("WebCam").GetComponent<WebCam>().ValorInicial();
		GameObject.Find("Config").GetComponent<Button>().interactable = true;
        Destroy(GameObject.FindWithTag("Confir"));
    }
}
