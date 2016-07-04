using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Net;

public class WebCam : MonoBehaviour {
   
	public WebCamTexture webcamTex;
    RawImage imagemWebCam;
    public int NumeroFoto = 0;
	public float tempoTotal;
	private bool comecarContagem;
    private bool tirarFoto;
    public GameObject confir;
    private GameObject instConf;
    private Texture2D foto;

    void Start () {
		//Variaveis
        webcamTex = new WebCamTexture();
        RawImage imagemWebCam  = GetComponent<RawImage>();
        imagemWebCam.texture = webcamTex;
        ValorInicial();
		GameObject.Find("Canvas").GetComponent<VariavelSave>().LerVariavel();

    }
    
    //Clicando em qualquer botao ativa o inicia a contagem 
    public void TirarFoto(){
        comecarContagem = true;
	}

    void Update()
    {

        GameObject.Find("Tempo").GetComponent<Text>().text = tempoTotal.ToString("F0");

        //contagem regressiva 
        if (tempoTotal > 0.5 && comecarContagem)
        {
            UiVisivel(true);
            tempoTotal = tempoTotal - Time.deltaTime;
            //comecarContagem = false;

        }
        //Tira a foto e salvar;
        if (tempoTotal <= 0.5f && tirarFoto)
        {
            GameObject.Find("Flash").GetComponent<RawImage>().enabled = true;
            webcamTex.Pause();
            UiVisivel(false);
            GameObject.Find("Flash").GetComponent<RawImage>().CrossFadeAlpha(0, 1, false);
            tirarFoto = false;
            instConf = GameObject.Instantiate(confir) as GameObject;
            instConf.transform.SetParent(GameObject.Find("Canvas").transform);
            instConf.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
            GameObject.Find("Config").GetComponent<Button>().interactable = false;
        }

        if (tempoTotal <= 2f && tirarFoto)
        {
            GameObject.Find("dedao").GetComponent<Animator>().SetTrigger("dedaoFoto");
        }
    }
   //Salva Foto
    public void SalvarFoto()
	{
        foto = new Texture2D(webcamTex.width, webcamTex.height);
		foto.SetPixels (webcamTex.GetPixels ());
		foto.Apply ();

        if (!Directory.Exists((System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/Fotos")))
        {
            Directory.CreateDirectory((System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/Fotos"));
        }
		System.IO.File.WriteAllBytes(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/Fotos/Foto_" + NumeroFoto.ToString () + ".jpg", foto.EncodeToJPG (80));
        FTPMetodo();
		++NumeroFoto;


    }

	//Deixa visivel ou invivisivel as Mensagens
	public void UiVisivel(bool visibilidade)
	{
		GameObject.Find("Sorria").GetComponent<Text> ().enabled = visibilidade;
		GameObject.Find("Msg").GetComponent<Text> ().enabled = visibilidade;
		GameObject.Find("Tempo").GetComponent<Text> ().enabled = visibilidade;
	}

    public void ValorInicial() {
        webcamTex.Play();
        comecarContagem = false;
        tirarFoto = true;
        UiVisivel(false);
        GameObject.Find("Flash").GetComponent<RawImage>().enabled = false;
        if (tempoTotal < 1)
        {
            tempoTotal = GameObject.Find("Config").GetComponent<Config>().valorTempo;
        }
		else
		{
			GameObject.Find("Config").GetComponent<Config>().valorTempo = tempoTotal;
		}

    }

    public void FTPMetodo()
    {

        //Comunicando com o servidor

        FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://agenciashift.com.br/foto_" + NumeroFoto + ".jpg");
        request.Method = WebRequestMethods.Ftp.UploadFile;

        // credenciais
        request.Credentials =
            new NetworkCredential("donanina@agenciashift.com.br", "1224364848");

        // lendo o a lista de bytes do arquivo
        byte[] bytes = System.IO.File.ReadAllBytes(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/Fotos/Foto_" + NumeroFoto.ToString() + ".jpg");

        // gravando para fazer upload
        request.ContentLength = bytes.Length;
        using (Stream request_stream = request.GetRequestStream())
        {
            request_stream.Write(bytes, 0, bytes.Length);
            request_stream.Close();
        }
    }
}