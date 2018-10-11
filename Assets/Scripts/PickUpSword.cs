using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSword : MonoBehaviour,ICharacterEnter {
    public GameObject sword;
    
    public void CharacterEnterInteract()
    {
        Animator anim = PlayerManager.Instance.anim;
        anim.SetTrigger("PickUpSword");
        this.gameObject.SetActive(false);
        SetSwordActive();
    }
    void SetSwordActive()
    {
        QuestManager.SetQuestAction(Quest.PickUpSword);
        PlayerManager.Instance.EquipSword();
    }
}
