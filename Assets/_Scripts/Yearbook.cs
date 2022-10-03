using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yearbook : MonoBehaviour
{
    private YearbookEntry[] yearbookEntries;

    private void Awake()
    {
        this.yearbookEntries = GetComponentsInChildren<YearbookEntry>();
        this.PopulateYearbook();
    }

    private void PopulateYearbook()
    {
        for (int i = 0; i < PhotoAlbum.photos.Count; i++)
        {
            this.yearbookEntries[i].SetupYearbookEntry(PhotoAlbum.photos[i]);
        }
    }
}
