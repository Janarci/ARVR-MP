using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftUI : MonoBehaviour
{
    [SerializeField] private Gift gift;
    [SerializeField] private Image thumbnail;
    // Start is called before the first frame update
    void Start()
    {
        thumbnail.sprite = gift.prefabImage;
    }

    public void GiveGift()
    {
        AffectionLevelManager.instance.AddAffection(gift);
    }
}
