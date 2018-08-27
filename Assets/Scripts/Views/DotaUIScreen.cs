using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DotaUIScreen : View {
    [SerializeField] private HeroData[] heroes;

    [SerializeField] private DotaPanelUI heroUITemplate;
    [SerializeField] private Transform spawnParent;

    private DotaPanelUI[] heroUIList;

	// Use this for initialization
	void Start () {
        this.heroUITemplate.gameObject.SetActive(false);
        this.InitializeUI();
	}

    private void InitializeUI() {
        this.heroUIList = new DotaPanelUI[this.heroes.Length];
        for (int i = 0; i < heroes.Length; i++) {
            this.heroUIList[i] = GameObject.Instantiate<DotaPanelUI>(this.heroUITemplate, this.spawnParent);
            this.heroUIList[i].SetInfo(this.heroes[i].GetHeroIcon(), this.heroes[i].GetHeroName(), this.heroes[i].GetHeroDesc(), this.heroes[i].GetSkillData());
            this.heroUIList[i].gameObject.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMainMenuClicked() {
        LoadManager.Instance.LoadScene(SceneNames.UI_DEMO_SCENE);
    }
}
