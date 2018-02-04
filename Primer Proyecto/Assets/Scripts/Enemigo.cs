using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Enemigo : MonoBehaviour {
	 
	public GameObject punto1, punto2, punto3;
	public Vector2 positionPunto1, positionPunto2, positionPunto3;
	public float velocidad = 1f;

	public bool punto1listo = false, punto2listo = false;
	// Use this for initialization
	void Start () {

		punto1 = GameObject.Find ("Punto1");
		punto2 = GameObject.Find ("Punto2");
		punto3 = GameObject.Find ("Punto3");

		positionPunto1 = GameObject.Find("Punto1").transform.position;
		positionPunto2 = GameObject.Find("Punto2").transform.position;
		positionPunto3 = GameObject.Find("Punto3").transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (punto1listo == false) {
			
			if (transform.position.x != positionPunto1.x && transform.position.y != positionPunto1.y) {
				transform.position = Vector3.MoveTowards (transform.position, positionPunto1, velocidad);
			} 

			else {
				
				punto1listo = true;
			}

		}


		else if (punto2listo == false){
			
			if (transform.position.x != positionPunto2.x && transform.position.y != positionPunto2.y) {
				
				transform.position = Vector3.MoveTowards (transform.position, positionPunto2, velocidad);

			} 

			else {

				punto2listo = true;
			}
		}

		else
		{
			transform.position = Vector3.MoveTowards (transform.position, positionPunto3, velocidad);
		}

	}
}
