using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEventSetActive : MonoBehaviour {
    public Quest desiredQuest;
    public GameObject[] targets;
    private void OnEnable()
    {
        QuestManager.OnQuestCompleted += OnQuestCompleted;

    }
    private void OnDisable()
    {
        QuestManager.OnQuestCompleted -= OnQuestCompleted;
    }
    void OnQuestCompleted(Quest quest)
    {
        if(quest == desiredQuest)
        {
            foreach (GameObject temp in targets)
            {
                temp.SetActive(true);
            }
        }

    }
    // Use this for initialization
    void Awake () {
        foreach(GameObject temp in targets)
        {
            temp.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
