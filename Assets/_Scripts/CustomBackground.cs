using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBackground : MonoBehaviour
{
    [SerializeField]
    private Material bgMaterial;

    private Texture2D[] allTextures;

    public void SetRandomBackground()
    {
        this.allTextures = Resources.LoadAll<Texture2D>("BGTextures");

        this.bgMaterial.mainTexture = this.allTextures[Random.Range(0, this.allTextures.Length)];
    }
}
