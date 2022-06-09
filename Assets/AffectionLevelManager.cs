using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AffectionLevelManager : MonoBehaviour
{
    [SerializeField] private int curLevel = 1;
    [SerializeField] private int maxLevel = 5;
    [SerializeField] private float curAffection;
    [SerializeField] private AnimationCurve maxAffectionPerLevel;

    [Header("UI")]
    [SerializeField] private Image bar;
    [SerializeField] private TextMeshProUGUI levelText;

    [HideInInspector]
    [Range(0.0f, 1.0f)] private float fillPercent; // curAffection / maxAffectionPerLevel
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
    void Update()
    {
        bar.fillAmount = fillPercent;
        levelText.text = curLevel.ToString();
    }

    #region Affection Level Up Functions
    public void AddAffection(float additional)
    {
        if(curLevel == maxLevel)
        {
            Debug.Log("");
            return;
        }
        curAffection += additional;
        fillPercent = curAffection / maxAffectionPerLevel.Evaluate(curLevel);
        if (fillPercent >= 1.0f)
        {
            LevelUp();
        }
        bar.fillAmount = fillPercent;
    }

    void LevelUp()
    {
        curLevel += 1;
        curAffection = 0.0f;
        fillPercent = curAffection / maxAffectionPerLevel.Evaluate(curLevel);
    }
    #endregion
}
