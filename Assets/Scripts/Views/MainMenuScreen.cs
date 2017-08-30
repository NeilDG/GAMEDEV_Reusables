using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : View {

	// Use this for initialization
	void Start () {
		
	}

	public void OnUIDemoClicked() {
		LoadManager.Instance.LoadScene (SceneNames.UI_DEMO_SCENE);
	}
}
