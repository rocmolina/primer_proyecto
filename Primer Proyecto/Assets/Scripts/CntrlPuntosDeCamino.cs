using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CntrlPuntosDeCamino : MonoBehaviour {

	//Conjunto que recopilara la info de todos los puntos.
	public static Transform[] puntos;

	//Awake es lo primero que ocurre al dar play
	void Awake () {

		puntos = new Transform[transform.childCount];

		for (int i = 0; i < puntos.Length; ++i) {

			puntos [i] = transform.GetChild (i);
		}
	}
}
