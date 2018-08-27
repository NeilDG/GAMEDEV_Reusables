using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUIScreen : View {

    [SerializeField] private SkillPanelUI skillUITemplate;
    [SerializeField] private Transform parent;

    private SkillData[] skills;
    private SkillPanelUI[] skillUIList;

    // Use this for initialization
    void Start () {
        this.skillUITemplate.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InstantiateUI() {
        this.skillUIList = new SkillPanelUI[this.skills.Length];
        for(int i = 0; i < skills.Length; i++) {
            this.skillUIList[i] = GameObject.Instantiate<SkillPanelUI>(this.skillUITemplate, parent);
            this.skillUIList[i].SetInfo(this.skills[i].GetSkillIcon(), this.skills[i].GetSkillName(), this.skills[i].GetSkillDesc());
            this.skillUIList[i].gameObject.SetActive(true);
            
        }
    }

    public void SetSkillData(SkillData[] skills) {
        this.skills = skills;

        this.InstantiateUI();
    }

    public void OnBackClicked() {
        this.Hide();
    }
}
