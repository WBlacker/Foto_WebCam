using UnityEngine;
using System.Collections;
using System.IO;

public class VariavelSave : MonoBehaviour {

	private string ValorNumero;

	public void SalvarVariavel(){
		ValorNumero = GameObject.Find("WebCam").GetComponent<WebCam>().NumeroFoto.ToString();
		File.WriteAllText(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/Fotos/NumeroDeFotos.txt",ValorNumero);
	}

	public void LerVariavel(){
		if (File.ReadAllText (System.Environment.GetFolderPath (System.Environment.SpecialFolder.Desktop) + "/Fotos/NumeroDeFotos.txt") != null) {
			ValorNumero = File.ReadAllText (System.Environment.GetFolderPath (System.Environment.SpecialFolder.Desktop) + "/Fotos/NumeroDeFotos.txt");
			GameObject.Find ("WebCam").GetComponent<WebCam> ().NumeroFoto = int.Parse(ValorNumero);
			Debug.Log ("Leu");
		} else {
			File.CreateText (System.Environment.GetFolderPath (System.Environment.SpecialFolder.Desktop) + "/Fotos/NumeroDeFotos.txt");
			SalvarVariavel ();
		}
	}
}
