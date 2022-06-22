using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftUI : MonoBehaviour
{
    [SerializeField] private int numberOfGifts = 10;
    [SerializeField] private Gift gift;
    [SerializeField] private Image thumbnail;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //Set gift image to the thumbnail of the button
        thumbnail.sprite = gift.prefabImage;
    }

    public void GiveGift()
    {
        if(numberOfGifts <= 0)
        {
            return;
        }
        //Get the AffectionLevelManager singleton and call the AddAffection function and set the gift as the parameter
        //Then remove 1 from numberOfGifts
        AffectionLevelManager.instance.AddAffection(gift);
        anim.SetTrigger("GivenGift");
        numberOfGifts -= 1;
    }

    public void AddGift()
    {
        //Add 1 gift
        numberOfGifts += 1;
    }
}
