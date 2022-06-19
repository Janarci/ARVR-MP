using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatUI : MonoBehaviour
{
    [SerializeField] private Button date1;
    [SerializeField] private Button date2;
    [SerializeField] private Button date3;

    [SerializeField] private Button decision1;
    [SerializeField] private Button decision2;
    [SerializeField] private Button decision3;

    [SerializeField] private Text decisionText1;
    [SerializeField] private Text decisionText2;
    [SerializeField] private Text decisionText3;

    [SerializeField] private Text ChatBox;
    [SerializeField] private GameObject ChatBoxArrow;
    [SerializeField] private Text ChatLog;

    [SerializeField] private GameObject ChatBoxParent;

    private int currentDate = 0;
    private int currentDS = 0;
    private int currentDD = 0;

    private bool pauseMouseClick = false;

    private List<DateScenario> Date1 = new List<DateScenario>(5);
    private List<DateScenario> Date2 = new List<DateScenario>(5);
    private List<DateScenario> Date3 = new List<DateScenario>(4);

    // Start is called before the first frame update
    void Start()
    {
        InitDate1();
        InitDate2();
        InitDate3();
        date1.interactable = true;
        date2.interactable = false;
        date3.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDate == 0)
        {
            date1.gameObject.SetActive(true);
            date2.gameObject.SetActive(true);
            date3.gameObject.SetActive(true);
            DisableAllUI();
        }
        else 
        {
            ChatBoxParent.SetActive(true);
            date1.gameObject.SetActive(false);
            date2.gameObject.SetActive(false);
            date3.gameObject.SetActive(false);
            DialogueControl();
            Debug.Log("currentDS: " + currentDS);
            Debug.Log("currentDD: " + currentDD);
            Debug.Log("1ds2 count: " + Date1[2].dateDialogueCount);
            DecisionHider();
        }
        if (currentDate == 1)
        {
            if (currentDS < Date1.Count)
            {
                setTextBoxes(currentDS, currentDD);
                if (Date1[currentDS].dateDialogues[currentDD].isNextDecision == true)
                {
                    setDecisions(currentDS, currentDD);
                    DecisionControls();
                }
            }
            else
            {
                date2.interactable = true;
                currentDate = 0;
            }
        }
        else if (currentDate == 2)
        {
            setTextBoxes(currentDS, currentDD);
            if (currentDS < Date2.Count)
            {
                if (Date2[currentDS].dateDialogues[currentDD].isNextDecision == false)
                {
                    if (Input.GetMouseButtonDown(0) && !pauseMouseClick)
                    {
                        currentDD++;
                    }
                }
                else
                {
                    setDecisions(currentDS, currentDD);
                    DecisionControls();
                }
            }
            else
            {
                date3.interactable = true;
                currentDate = 0;
            }
        }
        else if (currentDate == 3)
        {
            setTextBoxes(currentDS, currentDD);
            if (currentDS < Date3.Count)
            {
                if (Date3[currentDS].dateDialogues[currentDD].isNextDecision == false)
                {
                    if (Input.GetMouseButtonDown(0) && !pauseMouseClick)
                    {
                        currentDD++;
                    }
                }
                else
                {
                    setDecisions(currentDS, currentDD);
                    DecisionControls();
                }
            }
            else
            {
                currentDate = 0;
            }
        }
    }

    private void InitDate1()
    {
        DateScenario DateScene0 = new DateScenario();
        Date1.Add(DateScene0);
        int ds = 0;
        Date1[ds].dateDialogues = new Dialogue[1];
        Date1[ds].dateDialogues[0] = new Dialogue();
        //start scene
        Date1[ds].dateDialogues[0].statement = "The night soon engulfed the city as you both enjoyed the sunset hue of the park’s sky.";
        Date1[ds].dateDialogues[0].who = Dialogue.character.NONE;
        Date1[ds].dateDialogues[0].isNextDecision = false;
        Date1[ds].dateDialogueCount = 1;

        DateScenario DateScene1 = new DateScenario();
        Date1.Add(DateScene1);
        ds = 1;
        Date1[ds].dateDialogues = new Dialogue[3];
        Date1[ds].dateDialogues[0] = new Dialogue();
        Date1[ds].dateDialogues[1] = new Dialogue();
        Date1[ds].dateDialogues[2] = new Dialogue();
        Date1[ds].dateDialogues[1].decisions = new string[2];
        //DS1 - girl
        Date1[ds].dateDialogues[0].statement = "...Thanks for the date today. I really enjoyed it.";
        Date1[ds].dateDialogues[0].who = Dialogue.character.GIRL;
        Date1[ds].dateDialogues[0].isNextDecision = false;
        //player
        Date1[ds].dateDialogues[1].statement = "...Thanks for the date today. I really enjoyed it.";
        Date1[ds].dateDialogues[1].who = Dialogue.character.PLAYER;
        Date1[ds].dateDialogues[1].isNextDecision = true;
        Date1[ds].dateDialogues[1].decisions[0] = "Me too. We should do this again.";
        Date1[ds].dateDialogues[1].decisions[1] = "...I wish this day would never end.";
        //girl speaks if decision[1]
        Date1[ds].dateDialogues[2].statement = "Same here. But it’s getting dark so we should head home.";
        Date1[ds].dateDialogues[2].who = Dialogue.character.GIRL;
        Date1[ds].dateDialogues[2].isNextDecision = false;
        Date1[ds].dateDialogueCount = 3;

        DateScenario DateScene2 = new DateScenario();
        Date1.Add(DateScene2);
        ds = 2;
        Date1[ds].dateDialogues = new Dialogue[3];
        Date1[ds].dateDialogues[0] = new Dialogue();
        Date1[ds].dateDialogues[1] = new Dialogue();
        Date1[ds].dateDialogues[2] = new Dialogue();
        Date1[ds].dateDialogues[1].decisions = new string[2];
        //DS2 - girl
        Date1[ds].dateDialogues[0].statement = "Bye-bye! Talk to you later on SNS.";
        Date1[ds].dateDialogues[0].who = Dialogue.character.GIRL;
        Date1[ds].dateDialogues[0].isNextDecision = false;
        //player
        Date1[ds].dateDialogues[1].statement = "Bye-bye! Talk to you later on SNS.";
        Date1[ds].dateDialogues[1].who = Dialogue.character.PLAYER;
        Date1[ds].dateDialogues[1].isNextDecision = true;
        Date1[ds].dateDialogues[1].decisions[0] = "- Watch as she leaves before going home -";
        Date1[ds].dateDialogues[1].decisions[1] = "I’ll walk you home.";
        //narrator msg if decision[0]
        Date1[ds].dateDialogues[2].statement = "As you walk home, you pondered what would happen if you chose to accompany her home.";
        Date1[ds].dateDialogues[2].who = Dialogue.character.NONE;
        Date1[ds].dateDialogues[2].isNextDecision = false;
        //minigame if decision[1]
        Date1[ds].dateDialogueCount = 3;

        DateScenario DateScene3 = new DateScenario();
        Date1.Add(DateScene3);
        ds = 3;
        Date1[ds].dateDialogues = new Dialogue[3];
        Date1[ds].dateDialogues[0] = new Dialogue();
        Date1[ds].dateDialogues[1] = new Dialogue();
        Date1[ds].dateDialogues[2] = new Dialogue();
        //DS3 - if game complete - narrator in game
        Date1[ds].dateDialogues[0].statement = "The quiet streets made you feel that you both are the last people on earth. However, the convenience store sign comes into view, finally ending the time you spent together today.";
        Date1[ds].dateDialogues[0].who = Dialogue.character.NONE;
        Date1[ds].dateDialogues[0].isNextDecision = false;
        //girl speaks
        Date1[ds].dateDialogues[1].statement = "This should be far enough, I can go home by myself.";
        Date1[ds].dateDialogues[1].who = Dialogue.character.GIRL;
        Date1[ds].dateDialogues[1].isNextDecision = false;
        //narration after
        Date1[ds].dateDialogues[2].statement = "She starts walking home but stops immediately. She quickly approaches you, planting a kiss on your cheek as she bashfully runs home. (+10 Affection)";
        Date1[ds].dateDialogues[2].who = Dialogue.character.NONE;
        Date1[ds].dateDialogues[2].isNextDecision = false;
        Date1[ds].dateDialogueCount = 3;

        DateScenario DateScene4 = new DateScenario();
        Date1.Add(DateScene4);
        ds = 4;
        Date1[ds].dateDialogues = new Dialogue[1];
        Date1[ds].dateDialogues[0] = new Dialogue();
        //DS4 - if game fail - narrator in game
        Date1[ds].dateDialogues[0].statement = "The labyrinthine streets proved to be a herculean task for you. You were lost for another 30 minutes before finally getting her home.";
        Date1[ds].dateDialogues[0].who = Dialogue.character.NONE;
        Date1[ds].dateDialogues[0].isNextDecision = false;
        Date1[ds].dateDialogueCount = 1;

    }

    private void InitDate2()
    {
        DateScenario DateScene0 = new DateScenario();
        Date2.Add(DateScene0);
        int ds = 0;
        Date2[ds].dateDialogues = new Dialogue[1];
        Date2[ds].dateDialogues[0] = new Dialogue();
        //start scene
        Date2[ds].dateDialogues[0].statement = "Taking a break from walking around, you both enjoy a crêpe from the nearby kiosk in the park.";
        Date2[ds].dateDialogues[0].who = Dialogue.character.NONE;
        Date2[ds].dateDialogues[0].isNextDecision = false;
        Date2[ds].dateDialogueCount = 1;

        DateScenario DateScene1 = new DateScenario();
        Date2.Add(DateScene1);
        ds = 1;
        Date2[ds].dateDialogues = new Dialogue[5];
        Date2[ds].dateDialogues[0] = new Dialogue();
        Date2[ds].dateDialogues[1] = new Dialogue();
        Date2[ds].dateDialogues[2] = new Dialogue();
        Date2[ds].dateDialogues[3] = new Dialogue();
        Date2[ds].dateDialogues[4] = new Dialogue();
        Date2[ds].dateDialogues[3].decisions = new string[1];
        //DS1 - girl
        Date2[ds].dateDialogues[0].statement = "Mmm…this crêpe is delicious!";
        Date2[ds].dateDialogues[0].who = Dialogue.character.GIRL;
        Date2[ds].dateDialogues[0].isNextDecision = false;
        //-
        Date2[ds].dateDialogues[1].statement = "I wish I could eat this every day. But…";
        Date2[ds].dateDialogues[1].who = Dialogue.character.GIRL;
        Date2[ds].dateDialogues[1].isNextDecision = false;
        //-
        Date2[ds].dateDialogues[2].statement = "Crêpe and sweets would get me fat.";
        Date2[ds].dateDialogues[2].who = Dialogue.character.GIRL;
        Date2[ds].dateDialogues[2].isNextDecision = false;
        //player
        Date2[ds].dateDialogues[3].statement = "Crêpe and sweets would get me fat.";
        Date2[ds].dateDialogues[3].who = Dialogue.character.PLAYER;
        Date2[ds].dateDialogues[3].isNextDecision = true;
        Date2[ds].dateDialogues[3].decisions[0] = "I like you just the way you are.";
        //narrator msg 
        Date2[ds].dateDialogues[4].statement = "She blushes and quickly turns away from you.";
        Date2[ds].dateDialogues[4].who = Dialogue.character.NONE;
        Date2[ds].dateDialogues[4].isNextDecision = false;
        Date2[ds].dateDialogueCount = 5;

        DateScenario DateScene2 = new DateScenario();
        Date2.Add(DateScene2);
        ds = 2;
        Date2[ds].dateDialogues = new Dialogue[1];
        Date2[ds].dateDialogues[0] = new Dialogue();
        Date2[ds].dateDialogues[0].decisions = new string[1];
        //DS2 - player
        Date2[ds].dateDialogues[0].statement = "She blushes and quickly turns away from you.";
        Date2[ds].dateDialogues[0].who = Dialogue.character.PLAYER;
        Date2[ds].dateDialogues[0].isNextDecision = true;
        Date2[ds].dateDialogues[0].decisions[0] = "Here. I have something for you.";
        //give present
        Date2[ds].dateDialogueCount = 1;

        DateScenario DateScene3 = new DateScenario();
        Date2.Add(DateScene3);
        ds = 3;
        Date2[ds].dateDialogues = new Dialogue[3];
        Date2[ds].dateDialogues[0] = new Dialogue();
        Date2[ds].dateDialogues[1] = new Dialogue();
        Date2[ds].dateDialogues[2] = new Dialogue();
        //DS3 - girl reacts good
        Date2[ds].dateDialogues[0].statement = "Uwaaah…This is the first time I’m getting a gift from you.";
        Date2[ds].dateDialogues[0].who = Dialogue.character.GIRL;
        Date2[ds].dateDialogues[0].isNextDecision = false;
        //-
        Date2[ds].dateDialogues[1].statement = "Thank you, I will cherish it!";
        Date2[ds].dateDialogues[1].who = Dialogue.character.GIRL;
        Date2[ds].dateDialogues[1].isNextDecision = false;
        //narration after
        Date2[ds].dateDialogues[2].statement = "Clutching the gift she got from you, she happily enjoyed the rest of the date. (+10 Affection)";
        Date2[ds].dateDialogues[2].who = Dialogue.character.NONE;
        Date2[ds].dateDialogues[2].isNextDecision = false;
        Date2[ds].dateDialogueCount = 3;

        DateScenario DateScene4 = new DateScenario();
        Date2.Add(DateScene4);
        ds = 4;
        Date2[ds].dateDialogues = new Dialogue[2];
        Date2[ds].dateDialogues[0] = new Dialogue();
        Date2[ds].dateDialogues[1] = new Dialogue();
        //DS4 - girl reacts bad
        Date2[ds].dateDialogues[0].statement = "A-ah. Thanks for the present.";
        Date2[ds].dateDialogues[0].who = Dialogue.character.GIRL;
        Date2[ds].dateDialogues[0].isNextDecision = false;
        //narration after
        Date2[ds].dateDialogues[1].statement = "After taking the break, she felt less enthusiastic for the rest of the date.";
        Date2[ds].dateDialogues[1].who = Dialogue.character.NONE;
        Date2[ds].dateDialogues[1].isNextDecision = false;
        Date2[ds].dateDialogueCount = 2;
        
    }

    private void InitDate3()
    {
        DateScenario DateScene0 = new DateScenario();
        Date3.Add(DateScene0);
        int ds = 0;
        Date3[ds].dateDialogues = new Dialogue[1];
        Date3[ds].dateDialogues[0] = new Dialogue();
        //start scene
        Date3[ds].dateDialogues[0].statement = "The hustle and bustle of the city psych you up for the rest of the day. Walking around hand-in-hand, the arcade’s sign catches her eye.";
        Date3[ds].dateDialogues[0].who = Dialogue.character.NONE;
        Date3[ds].dateDialogues[0].isNextDecision = false;
        Date3[ds].dateDialogueCount = 1;

        DateScenario DateScene1 = new DateScenario();
        Date3.Add(DateScene1);
        ds = 1;
        Date3[ds].dateDialogues = new Dialogue[9];
        Date3[ds].dateDialogues[0] = new Dialogue();
        Date3[ds].dateDialogues[1] = new Dialogue();
        Date3[ds].dateDialogues[2] = new Dialogue();
        Date3[ds].dateDialogues[3] = new Dialogue();
        Date3[ds].dateDialogues[4] = new Dialogue();
        Date3[ds].dateDialogues[5] = new Dialogue();
        Date3[ds].dateDialogues[6] = new Dialogue();
        Date3[ds].dateDialogues[7] = new Dialogue();
        Date3[ds].dateDialogues[8] = new Dialogue();
        //DS1 - girl
        Date3[ds].dateDialogues[0].statement = "...Thanks for the date today. I really enjoyed it.";
        Date3[ds].dateDialogues[0].who = Dialogue.character.GIRL;
        Date3[ds].dateDialogues[0].isNextDecision = false;
        //narration
        Date3[ds].dateDialogues[1].statement = "She takes your hand and guides you into the arcade.";
        Date3[ds].dateDialogues[1].who = Dialogue.character.NONE;
        Date3[ds].dateDialogues[1].isNextDecision = false;
        //girl
        Date3[ds].dateDialogues[2].statement = "Uwaaah… So this is what the arcade looks like inside.";
        Date3[ds].dateDialogues[2].who = Dialogue.character.GIRL;
        Date3[ds].dateDialogues[2].isNextDecision = false;
        //girl
        Date3[ds].dateDialogues[3].statement = "I have never been to one before. My parents told me that only delinquents go here.";
        Date3[ds].dateDialogues[3].who = Dialogue.character.GIRL;
        Date3[ds].dateDialogues[3].isNextDecision = false;
        //girl
        Date3[ds].dateDialogues[4].statement = "Hehe~ Feels like I’m doing something wrong with you.";
        Date3[ds].dateDialogues[4].who = Dialogue.character.GIRL;
        Date3[ds].dateDialogues[4].isNextDecision = false;
        //girl
        Date3[ds].dateDialogues[5].statement = "Ah! You will get a stuffed animal when you win on this Wack-A-Mole.";
        Date3[ds].dateDialogues[5].who = Dialogue.character.GIRL;
        Date3[ds].dateDialogues[5].isNextDecision = false;
        //narration
        Date3[ds].dateDialogues[6].statement = "She grabbed the hammer with confidence and started playing. However, her reflex time is just barely slower than the game.";
        Date3[ds].dateDialogues[6].who = Dialogue.character.NONE;
        Date3[ds].dateDialogues[6].isNextDecision = false;
        //girl
        Date3[ds].dateDialogues[7].statement = "Aww… I failed and I wanted the prize too…";
        Date3[ds].dateDialogues[7].who = Dialogue.character.GIRL;
        Date3[ds].dateDialogues[7].isNextDecision = false;
        //girl
        Date3[ds].dateDialogues[8].statement = "Here. Why don’t you try it out?";
        Date3[ds].dateDialogues[8].who = Dialogue.character.GIRL;
        Date3[ds].dateDialogues[8].isNextDecision = false;
        //buttons minigame
        Date3[ds].dateDialogueCount = 9;


        DateScenario DateScene2 = new DateScenario();
        Date3.Add(DateScene2);
        ds = 2;
        Date3[ds].dateDialogues = new Dialogue[3];
        Date3[ds].dateDialogues[0] = new Dialogue();
        Date3[ds].dateDialogues[1] = new Dialogue();
        Date3[ds].dateDialogues[2] = new Dialogue();
        //DS2 - girl if win
        Date3[ds].dateDialogues[0].statement = "YAY! Thank you for getting me this! It’s sooo cute.";
        Date3[ds].dateDialogues[0].who = Dialogue.character.GIRL;
        Date3[ds].dateDialogues[0].isNextDecision = false;
        //narrator msg 
        Date3[ds].dateDialogues[1].statement = "With her excitement, she instinctively hugged you. She looks happy that you got her a stuffed animal. (+10 Affection)";
        Date3[ds].dateDialogues[1].who = Dialogue.character.NONE;
        Date3[ds].dateDialogues[1].isNextDecision = false;
        //narrator msg 
        Date3[ds].dateDialogues[2].statement = "You both happily enjoyed your time playing in the arcade. You thought that bringing her to the arcade in the future would be a great idea.";
        Date3[ds].dateDialogues[2].who = Dialogue.character.NONE;
        Date3[ds].dateDialogues[2].isNextDecision = false;
        Date3[ds].dateDialogueCount = 3;

        DateScenario DateScene3 = new DateScenario();
        Date3.Add(DateScene3);
        ds = 3;
        Date3[ds].dateDialogues = new Dialogue[2];
        Date3[ds].dateDialogues[0] = new Dialogue();
        Date3[ds].dateDialogues[1] = new Dialogue();
        //DS3 - girl if lose
        Date3[ds].dateDialogues[0].statement = "The quiet streets made you feel that you both are the last people on earth. However, the convenience store sign comes into view, finally ending the time you spent together today.";
        Date3[ds].dateDialogues[0].who = Dialogue.character.GIRL;
        Date3[ds].dateDialogues[0].isNextDecision = false;
        //narration after
        Date3[ds].dateDialogues[1].statement = "She starts walking home but stops immediately. She quickly approaches you, planting a kiss on your cheek as she bashfully runs home. (+10 Affection)";
        Date3[ds].dateDialogues[1].who = Dialogue.character.NONE;
        Date3[ds].dateDialogues[1].isNextDecision = false;
        Date3[ds].dateDialogueCount = 2;



    }

    private void setTextBoxes(int currentDS, int currentDD)
    {
        if (currentDate == 1) 
        {
            if (currentDS < Date1.Count)
            {
                ChatBox.text = Date1[currentDS].dateDialogues[currentDD].statement;
            }
        }
        else if (currentDate == 2)
        {
            if (currentDS < Date2.Count)
            {
                ChatBox.text = Date2[currentDS].dateDialogues[currentDD].statement;
            }
        }
        else if (currentDate == 3)
        {
            if (currentDS < Date3.Count)
            {
                ChatBox.text = Date3[currentDS].dateDialogues[currentDD].statement;
            }
        }


    }
    private void setDecisions(int currentDS, int currentDD)
    {
        if (currentDate == 1)
        {
            decisionText1.text = Date1[currentDS].dateDialogues[currentDD].decisions[0];
            decision1.gameObject.SetActive(true);
            if (Date1[currentDS].dateDialogues[currentDD].decisions[1] != null)
            {
                decisionText2.text = Date1[currentDS].dateDialogues[currentDD].decisions[1];
                decision2.gameObject.SetActive(true);
            }
        }
        else if (currentDate == 2)
        {
            decisionText1.text = Date2[currentDS].dateDialogues[currentDD].decisions[0];
            decision1.gameObject.SetActive(true);
        }
        else if (currentDate == 3)
        {
            decisionText1.text = Date3[currentDS].dateDialogues[currentDD].decisions[0];
            decision1.gameObject.SetActive(true);
            if (Date3[currentDS].dateDialogues[currentDD].decisions[1] != null)
            {
                decisionText2.text = Date3[currentDS].dateDialogues[currentDD].decisions[1];
                decision2.gameObject.SetActive(true);
            }
        }
    }

    private void DecisionHider()
    {
        if (currentDate == 1)
        {
            if (currentDS < Date1.Count)
            {
                if (Date1[currentDS].dateDialogues[currentDD].who != Dialogue.character.PLAYER)
                {
                    decision1.gameObject.SetActive(false);
                    decision2.gameObject.SetActive(false);
                    decision3.gameObject.SetActive(false);
                }
            }
        }
        if (currentDate == 2)
        {
            if (currentDS < Date1.Count)
            {
                if (Date2[currentDS].dateDialogues[currentDD].who != Dialogue.character.PLAYER)
                {
                    decision1.gameObject.SetActive(false);
                    decision2.gameObject.SetActive(false);
                    decision3.gameObject.SetActive(false);
                }
            }
        }
        if (currentDate == 3)
        {
            if (currentDS < Date1.Count)
            {
                if (Date3[currentDS].dateDialogues[currentDD].who != Dialogue.character.PLAYER)
                {
                    decision1.gameObject.SetActive(false);
                    decision2.gameObject.SetActive(false);
                    decision3.gameObject.SetActive(false);
                }
            }
        }
        
    }

    private void DialogueControl()
    {
        if (currentDate == 1)
        {
            if (currentDS < Date1.Count)
            {
                if (currentDD >= Date1[currentDS].dateDialogueCount)
                {
                    currentDS++;
                    currentDD = 0;
                }
            }
        }
        if (currentDate == 2)
        {
            if (currentDS < Date2.Count)
            {
                if (currentDD >= Date2[currentDS].dateDialogueCount)
                {
                    currentDS++;
                    currentDD = 0;
                }
            }
        }
        if (currentDate == 3)
        {
            if (currentDS < Date3.Count)
            {
                if (currentDD >= Date3[currentDS].dateDialogueCount)
                {
                    currentDS++;
                    currentDD = 0;
                }
            }
        }
    }

    private void DecisionControls()
    {
        if (currentDate == 1 && currentDS == 1 && currentDD == 1)
        {
            decision1.onClick.AddListener(date111d1);
            decision2.onClick.AddListener(date111d2);
        }
        else if (currentDate == 1 && currentDS == 2 && currentDD == 1)
        {
            decision1.onClick.AddListener(date121d1);
            decision2.onClick.AddListener(date121d2);
        }
        else if (currentDate == 2 && currentDS == 1 && currentDD == 3)
        {
            decision1.onClick.AddListener(ButtonProceedDialogue);
        }
        else if (currentDate == 2 && currentDS == 2 && currentDD == 0)
        {
            decision1.onClick.AddListener(ButtonProceedDialogue);
        }
    }

    public void ButtonSetDate1()
    {
        currentDate = 1;
        currentDD = 0;
        currentDS = 0;
    }
    public void ButtonSetDate2()
    {
        currentDate = 2;
        currentDD = 0;
        currentDS = 0;
    }
    public void ButtonSetDate3()
    {
        currentDate = 3;
        currentDD = 0;
        currentDS = 0;
    }
    private void date111d1()
    {
        currentDD = 3;
    }

    private void date111d2()
    {
        currentDD = 2;
    }

    private void date121d1()
    {
        currentDD = 2;
    }

    private void date121d2()
    {
        //load game
    }

    private void ButtonProceedDialogue()
    {
        currentDD++;
    }

    private void ButtonProceedMazeGame()
    {
        //load game
    }

    private void StartButtonGame()
    {
        //load game
    }

    private void DisableAllUI()
    {
        decision1.gameObject.SetActive(false);
        decision2.gameObject.SetActive(false); 
        decision3.gameObject.SetActive(false);

        ChatBoxParent.SetActive(false);
    }

    public void ProceedTextButton()
    {
        if (Date1[currentDS].dateDialogues[currentDD].isNextDecision == false)
        {
            currentDD++;
        }
    }
}
