using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AffectionLevelManager : MonoBehaviour
{
    public static AffectionLevelManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("Multiple instance of AffectionLevelManager Exists");
    }

    [SerializeField] private int curLevel = 1;
    [SerializeField] private int maxLevel = 5;
    [SerializeField] private int curAffection;
    [SerializeField] private AnimationCurve maxAffectionPerLevel;

    [Header("UI")]
    [SerializeField] private Image bar;
    [SerializeField] private TextMeshProUGUI levelText;

    [HideInInspector]
    [Range(0.0f, 1.0f)] private float fillPercent; // curAffection divided by maxAffectionPerLevel
    // Start is called before the first frame update
    void Start()
    {
        #region Initializing UI
        if (TryGetComponent<Image>(out Image img) && bar != null)
        {
            bar = img;
        }
        if(TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI txt) && 
            levelText != null)
        {
            levelText = txt;
        }
        #endregion
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if current level is below the maximum level
        if(curLevel < maxLevel)
        {
            bar.fillAmount = fillPercent;
            levelText.text = curLevel.ToString();
        }
        else
        {
            bar.fillAmount = 1;
            levelText.text = "MAX";
        }
    }

    #region Affection Level Up Functions
    public void AddAffection(Gift gift)
    {
        //Gets the value of the Gift and checks if it can be applied to the girt
        if(curLevel == maxLevel)
        {
            Debug.Log("");
            return;
        }
        curAffection += gift.Affection;
        fillPercent = (float)curAffection / maxAffectionPerLevel.Evaluate(curLevel);
        //if the XP reaches 100 reset the curAffection to 0 and +1 level
        if (fillPercent >= 1.0f)
        {
            LevelUp();
        }
    }

    public void AddAffectionOnEvent(int value)
    {
        //Gets the value of the Gift and checks if it can be applied to the girt
        if (curLevel == maxLevel)
        {
            Debug.Log("");
            return;
        }
        curAffection += value;
        fillPercent = (float)curAffection / maxAffectionPerLevel.Evaluate(curLevel);
        //if the XP reaches 100 reset the curAffection to 0 and +1 level
        if (fillPercent >= 1.0f)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        curLevel += 1;
        curAffection = 0;
        fillPercent = (float)curAffection / maxAffectionPerLevel.Evaluate(curLevel);
    }
    #endregion
}
