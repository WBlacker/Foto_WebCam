using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class WebCam : MonoBehaviour {

	WebCamTexture webcamTex;
    RawImage imagemWebCam;
    private string localSalvar = "C:/FotosTeste/";
    int NumeroFoto = 0;
	public float tempoTotal;
	private bool comecarContagem = false;
    private bool salvarFoto =  true;

    void Start () {
		//Variaveis
        webcamTex = new WebCamTexture();
        RawImage imagemWebCam  = GetComponent<RawImage>();
        imagemWebCam.texture = webcamTex;
        webcamTex.Play();
		UiVisivel (false);
    }

	void OnMouseEnter(){
		Debug.Log ("Loguei");
	}

	void Update () {
        GameObject.Find("Tempo").GetComponent<Text>().text = tempoTotal.ToString("F0");

		//Clicando em qualquer botao ativa o inicia a contagem 
		if(Input.GetKey(KeyCode.A))
		{
			comecarContagem = true;
		}

		//contagem regressiva 
		if(tempoTotal > 0.5 && comecarContagem)
		{
			UiVisivel (true);
			tempoTotal = tempoTotal - Time.deltaTime;
			//comecarContagem = false;
            
		}
		//Tira a foto e salva;
        if (tempoTotal <= 0.5f && salvarFoto) {
            GameObject.Find("Flash").GetComponent<RawImage>().enabled = true;
			SalvarFoto();
			UiVisivel (false);
            GameObject.Find("Flash").GetComponent<RawImage>().CrossFadeAlpha(0, 1, false);
            salvarFoto = false;
        }
	
	}

   //Salva Foto
    void SalvarFoto()
	{
        Texture2D foto = new Texture2D(webcamTex.width, webcamTex.height);
		foto.SetPixels (webcamTex.GetPixels ());
		foto.Apply ();

		System.IO.File.WriteAllBytes (Application.dataPath + NumeroFoto.ToString () + ".png", foto.EncodeToPNG ());
		++NumeroFoto;
        webcamTex.Pause();
        Debug.Log("salvou");

    }

	//Deixa visivel ou invivisivel as Mensagens
	void UiVisivel(bool visibilidade)
	{
		GameObject.Find("Sorria").GetComponent<Text> ().enabled = visibilidade;
		GameObject.Find("Msg").GetComponent<Text> ().enabled = visibilidade;
		GameObject.Find("Tempo").GetComponent<Text> ().enabled = visibilidade;
	}

	public void Config(){
		Debug.Log ("Slavar");
	}
}