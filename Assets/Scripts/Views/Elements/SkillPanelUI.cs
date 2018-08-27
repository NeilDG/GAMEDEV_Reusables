using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPanelUI : MonoBehaviour {

    [SerializeField] private RawImage image;
    [SerializeField] private Text skillName;
    [SerializeField] private Text skillDesc;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetInfo(Texture texture, string skillName, string skillDesc) {
        this.image.texture = texture;
        this.skillName.text = skillName;
        this.skillDesc.text = skillDesc;
    }
}
