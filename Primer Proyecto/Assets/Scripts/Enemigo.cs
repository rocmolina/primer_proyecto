using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Enemigo : MonoBehaviour {
	 
	//variable que controla la velocidad
	[Header("Atributos")]
	public float velocidad = 1f;
	public float velocidadGiro = 1f;

	//variable que controla el objetivo actual donde debe ir el enemigo
	private Transform objetivo;
	//variable que hace referncia a la sussecion de puntos en el script CntrlPuntosDeCamino 
	private int PuntoIndex = 0;
	//Variable que obtiene la direccion
	private Vector3 direccion;
	// Use this for initialization
	void Start () {

		//Se elige el primer punto del conjunto
		objetivo = CntrlPuntosDeCamino.puntos [0];
	}
	
	// Update is called once per frame
	void Update () {

		//se obtiene la direccion en la que debe ir el enemigo
	    direccion = objetivo.position - transform.position;
		//se mueve al enemigo
		VerificarDireccion ();
		transform.Translate (direccion.normalized * velocidad * Time.deltaTime, Space.World);

		//verifica si el enemigo llego al objetivo actual
		if (Vector3.Distance (transform.position, objetivo.position) < 0.025f) {

			transform.position = objetivo.position;
			ActivarSiguienteObjetivo ();
		}
	}

	//Aumenta el numero del Index para pasar al siguiente punto del conjunto
	void ActivarSiguienteObjetivo()
	{
		PuntoIndex++;
		//Verifica si el enemigo ya llego al final
		if (PuntoIndex >= CntrlPuntosDeCamino.puntos.Length) {

			TrayectoCompletado ();
			return;
		} 

		else {
			
			objetivo = CntrlPuntosDeCamino.puntos [PuntoIndex];
		}
	}

	//Se llama cuando el enemigo llega al final
	void TrayectoCompletado()
	{
		//Destruye al enemigo que ha llegado a su destino final lol
		Destroy (gameObject);
	}

	//trabajando actualmente
	void VerificarDireccion()
	{
		Vector3 nuevaRotacion;
		Quaternion dirRotacion = Quaternion.LookRotation (direccion);
		nuevaRotacion = dirRotacion.eulerAngles;
		transform.rotation = Quaternion.Euler(0f,0f, nuevaRotacion.z);
	}

}
