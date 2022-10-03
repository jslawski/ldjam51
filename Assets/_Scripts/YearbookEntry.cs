using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class YearbookEntry : MonoBehaviour
{    
    [SerializeField]
    private RawImage image;
    [SerializeField]
    private TextMeshProUGUI characterName;
    [SerializeField]
    private TextMeshProUGUI quote;
    [SerializeField]
    private Image scoreImage;

    // Start is called before the first frame update
    public void SetupYearbookEntry(PhotoData yearbookPhoto)
    {
        this.image.texture = yearbookPhoto.textureData;
        this.characterName.text = yearbookPhoto.studentName;
        this.quote.text = yearbookPhoto.quote;

        if (yearbookPhoto.score >= GameManager.instance.perfectScore)
        {
            this.scoreImage.sprite = Resources.Load<Sprite>("UI/Yearbook/scorePin_Perfect");
        }
        else if (yearbookPhoto.score >= GameManager.instance.perfectScore)
        {
            this.scoreImage.sprite = Resources.Load<Sprite>("UI/Yearbook/scorePin_Good");
        }
        else
        {
            this.scoreImage.enabled = false;
        }
    }
}
