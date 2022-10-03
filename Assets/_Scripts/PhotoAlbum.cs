using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhotoAlbum
{
    public static List<PhotoData> photos;

    public static void SetupPhotoAlbum()
    {
        photos = new List<PhotoData>();
    }

    public static void AddPhoto(PhotoData newPhoto)
    {
        photos.Add(newPhoto);
    }
}
