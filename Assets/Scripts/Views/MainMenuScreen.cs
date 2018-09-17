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

	public void OnObjectPoolClicked() {
		LoadManager.Instance.LoadScene (SceneNames.OBJECT_POOL_SCENE);
	}

	public void OnBroadcastingDemoClicked() {
		LoadManager.Instance.LoadScene (SceneNames.BROADCASTING_SCENE);
	}

	public void OnSceneLightingClicked() {
		//LoadManager.Instance.LoadScene (SceneNames.SCENE_LIGHTING);
        LoadManager.Instance.LoadScene(SceneNames.VISUAL_EFFECTS_MENU_SCENE);
    }

	public void OnAnimationSceneClicked() {
		LoadManager.Instance.LoadScene (SceneNames.ANIMATION_DEMO);
	}

    public void OnAdvancedAnimClicked()
    {
        LoadManager.Instance.LoadScene(SceneNames.ADVANCED_ANIMATION_SCENE);
    }

	public void OnParticleSceneClicked() {
		LoadManager.Instance.LoadScene (SceneNames.PARTICLE_EFFECT_DEMO);
	}

    public void OnPathfindingClicked() {
        LoadManager.Instance.LoadScene(SceneNames.PATHFINDING_SCENE);
    }
}
