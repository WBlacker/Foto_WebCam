using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Config : MonoBehaviour {

	public GameObject panel;
	private GameObject instPanel;
	public float valorTempo;
	public bool config = false;
    private bool pegarValor = true;


    public void ConfigButton()
	{
		instPanel = GameObject.Instantiate(panel, new Vector3(0,0,0), Quaternion.identity) as GameObject;
		instPanel.transform.SetParent(GameObject.Find("Canvas").transform);
        instPanel.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        config = true;
        pegarValor = true;
    }
	void Update()
	{
		if (config == true && GameObject.Find("Slider") != null)
        {
            GameObject.Find("WebCam").GetComponent<WebCam>().UiVisivel(false);
            mudarValor ();
        }

	}

	public void mudarValor()
	{
        if(pegarValor){
            GameObject.Find("Slider").GetComponent<Slider>().value = GameObject.Find("WebCam").GetComponent<WebCam>().tempoTotal = valorTempo;
            pegarValor = false;
        }
        valorTempo = GameObject.Find ("Slider").GetComponent<Slider>().value;
		GameObject.Find ("WebCam").GetComponent<WebCam>().tempoTotal = valorTempo;
		GameObject.Find ("TempoConfig").GetComponent<Text>().text = valorTempo.ToString("F0");
	}

    public void SalvarConfig() {
        config = false;
        GameObject.Find("WebCam").GetComponent<WebCam>().ValorInicial();
        GameObject.Find("Config").GetComponent<Button>().interactable = true;
        Destroy(GameObject.FindGameObjectWithTag("Info"));
    }

    public void Menos()
    {
        GameObject.Find("Slider").GetComponent<Slider>().value--;
    }

    public void Mais()
    {
        GameObject.Find("Slider").GetComponent<Slider>().value++;
    }

}
