using System.Collections;
using UnityEngine;

public class PhotoTaker : MonoBehaviour
{
    [HideInInspector]
    public Texture2D photoTexture;
    [HideInInspector]
    public Sprite photoSprite;
    RenderTexture savephotoRenderTexture;
    Texture2D savephotoTexture;

    private Material resultMaterial;

    private int photoId = 0;

    [SerializeField]
    private Animator photoAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        var renderTexture = GetComponent<Camera>().targetTexture;
        // create photoTexture
        photoTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false, true);
        // create photoSprite
        photoSprite = Sprite.Create(photoTexture, new Rect(0, 0, renderTexture.width, renderTexture.height), new Vector2(0.5f, 0.5f));

        // create savephotoRenderTexture
        savephotoRenderTexture = new RenderTexture(renderTexture.width, renderTexture.height, 0, RenderTextureFormat.ARGB32);

        // create savephotoTexture
        savephotoTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false, false);

        this.resultMaterial = Resources.Load<Material>("Materials/ResultMaterial");
    }

    public void StartTimer()
    {
        StartCoroutine(this.TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(10.0f);
        this.TakePhoto();
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        // copy renderTexture to photoTexture
        photoTexture.ReadPixels(new Rect(0, 0, src.width, src.height), 0, 0);
        photoTexture.Apply();
        // copy photoTexture to dest
        Graphics.Blit(photoTexture, dest);
    }

    public void TakePhoto()
    {
        // copy renderTexture to savephotoRenderTexture
        Graphics.Blit(GetComponent<Camera>().targetTexture, savephotoRenderTexture);

        // copy savephotoRenderTexture to savephotoTexture
        RenderTexture.active = savephotoRenderTexture;
        savephotoTexture.ReadPixels(new Rect(0, 0, savephotoRenderTexture.width, savephotoRenderTexture.height), 0, 0);
        savephotoTexture.Apply();
        RenderTexture.active = null;

        // save photoTexture to file
        var bytes = savephotoTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(Application.dataPath + "/Resources/Photos/photo" + this.photoId + ".png", bytes);

        this.photoId++;

        this.resultMaterial.mainTexture = savephotoTexture;

        this.photoAnimator.SetTrigger("ShowPhoto");
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            this.TakePhoto();
        }
    }

    private void OnDestroy()
    {
        // destroy photoTexture
        Destroy(photoTexture);

        // destroy savephotoRenderTexture
        savephotoRenderTexture.Release();

        // destroy savephotoTexture
        Destroy(savephotoTexture);
    }
}