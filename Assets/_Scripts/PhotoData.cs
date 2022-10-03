using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoData
{
    public string studentName;
    public string quote;
    public int score;
    public Texture2D textureData;
    
    public PhotoData(Texture2D sourceTexture)
    {
        this.studentName = GameManager.instance.characterName;
        this.quote = GameManager.instance.quote;
        this.score = GameManager.instance.levelScore;

        textureData = new Texture2D(sourceTexture.width, sourceTexture.height, TextureFormat.RGBA32, false, false);
        textureData.LoadRawTextureData(sourceTexture.GetRawTextureData());
        textureData.Apply();
    }

    ~PhotoData()
    {
        Object.Destroy(textureData);
    }
}
