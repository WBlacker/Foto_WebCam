using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Config : MonoBehaviour {

	public GameObject panel;
	private GameObject instPanel;
	private float valorTempo;
	public bool config;


	public void ConfigButton()
	{
		instPanel = GameObject.Instantiate(panel);
		instPanel.transform.SetParent(GameObject.Find("Canvas").transform);
		config = true;
	}
	void Update()
	{
		if (config == true){
			mudarValor ();
		}

	}

	public void mudarValor()
	{
		valorTempo = GameObject.Find ("Slider").GetComponent<Slider>().value;
		GameObject.Find ("WebCam").GetComponent<WebCam>().tempoTotal = valorTempo;
		GameObject.Find ("TempoConfig").GetComponent<Text>().text = valorTempo.ToString("F0");
	}

    public void SalvarConfig() {
        config = false;
        Destroy(GameObject.FindGameObjectWithTag("Info"));
    }
}
