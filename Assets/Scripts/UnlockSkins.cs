using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockSkins : MonoBehaviour {

    public GameObject bloqueo;

	void Start ()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform == transform.parent.GetChild(i))
            {
                if (PlayerPrefs.GetInt("Bloqueo" + i.ToString()) == 1)
                {
                    bloqueo.SetActive(false);  
                }
            }
        }
	}
}
