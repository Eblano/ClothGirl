using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//public class Quest
//{
//    public string name;
//    public bool completed;
//}
public enum Quest
{
    SetEdwardFree,
    PickUpSword
}
public static class Quests{
    public static bool savedEdFromNet = false;
}
public static class QuestManager{
    public delegate void QuestAction(Quest quest);
    public static event QuestAction OnQuestCompleted;
    public static void SetQuestAction(Quest quest)
    {
        if(OnQuestCompleted != null)
        OnQuestCompleted(quest);
    }
    // Use this for initialization
  
}
