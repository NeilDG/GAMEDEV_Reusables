using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotaPanelUI : MonoBehaviour {

    [SerializeField] private RawImage image;
    [SerializeField] private Text heroName;
    [SerializeField] private Text heroDesc;
    [SerializeField] private Button button;

    private SkillData[] skills;

	// Use this for initialization
	void Start () {
        if (this.button != null) {
            this.button.enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetInfo(Texture texture, string heroName, string heroDesc, SkillData[] skills) {
        this.image.texture = texture;
        this.heroName.text = heroName;
        this.heroDesc.text = heroDesc;
        this.skills = skills;
    }

    public void OnSkillClicked() {
        SkillUIScreen skillUIScreen = (SkillUIScreen) ViewHandler.Instance.Show(ViewNames.SKILL_UI_SCREEN);
        skillUIScreen.SetSkillData(this.skills);
    }
}
