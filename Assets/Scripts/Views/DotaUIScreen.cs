using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DotaUIScreen : View {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMainMenuClicked() {
        LoadManager.Instance.LoadScene(SceneNames.MAIN_SCENE);
    }
}
