using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinPlayer : MonoBehaviour {

    public Image[] skins;
    public Texture[] textures;
    public Renderer rend;

    public void Start()
    {
        cambiarSkin(PlayerPrefs.GetInt("Skin"));
    }

    public void cambiarSkin(int j)
    {
        switch (j)
        {
            case 0:
                rend.material.color = new Color(1, 0.5f, 0); ;
                rend.material.mainTexture = null;
                break;
            case 1:
                rend.material.color = Color.red;
                rend.material.mainTexture = null;
                break;
            case 2:
                rend.material.color = Color.green;
                rend.material.mainTexture = null;
                break;
            case 3:
                rend.material.color = Color.yellow;
                rend.material.mainTexture = null;
                break;
            case 4:
                rend.material.color = Color.magenta;
                rend.material.mainTexture = null;
                break;
            case 5:
                rend.material.color = Color.white;
                rend.material.mainTexture = textures[0];
                break;
            case 6:
                rend.material.color = Color.white;
                rend.material.mainTexture = textures[1];
                break;
            case 7:
                rend.material.color = Color.white;
                rend.material.mainTexture = textures[2];
                break;
            case 8:
                rend.material.color = Color.white;
                rend.material.mainTexture = textures[3];
                break;
        }
        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].gameObject.SetActive(false);
        }
        skins[j].gameObject.SetActive(true);
        PlayerPrefs.SetInt("Skin", j);
    }
}
