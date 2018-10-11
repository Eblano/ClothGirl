using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//edward script
public class NPCBehavior : MonoBehaviour {
    public Quest neededQuest;
    public Animator anim;
    public string animTrigger = "StandUp";
    public RPGTalkArea rpgTalkArea;
    public RPGTalk rpgTalk;
    public MonoBehaviour callBackScript;
    public NetFallAction netFallAction;
    public string functionName;
    public string startLine = "1";
    public string endLine = "1";


    int right = 1;
    int left = -1;
    int dir;
    public float speed = 1.45f;
    public bool isRunning = false;
    bool isRight = true;
    private void OnEnable()
    {
        netFallAction.OnFallAction += StartSavedText;
        QuestManager.OnQuestCompleted += QuestBehavior;
    }
    private void OnDisable()
    {
        netFallAction.OnFallAction -= StartSavedText;
        QuestManager.OnQuestCompleted -= QuestBehavior;
    }
    void QuestBehavior(Quest temp)
    {
        //when edward gets saved
        if(temp == neededQuest)
        {
            anim.SetTrigger(animTrigger);
            if(rpgTalk != null)
            rpgTalk.NewTalk(startLine, endLine, callBackScript, functionName);
        }
    }
    void StartSavedText()
    {
        rpgTalk.NewTalk(startLine, endLine, callBackScript, functionName);

    }
    void WalkAway()
    {
        isRunning = true;
        //auto movement script?
    }
    void Update()
    {
        if (isRight)
        {
            dir = right;
        }
        else
        {
            dir = left;
        }
        if (isRunning)
        {
            transform.parent = null;
            anim.SetBool("isWalking", true);
            transform.Translate(dir * Vector3.right * speed * Time.deltaTime);
        }

    }
}
