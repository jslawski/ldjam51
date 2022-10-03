using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhotoAlbum
{
    public static List<PhotoData> photos;

    public static void AddPhoto(PhotoData newPhoto)
    {
        if (photos == null)
        {
            photos = new List<PhotoData>();
        }

        photos.Add(newPhoto);
    }
}
