using UnityEngine;
using System.Collections;

public class AnimationControlDemo : MonoBehaviour {

	private MecanimControl mecanimControl;
	private bool mirror;
	private float animSpeed = 1f;
	private float blendDuration = .1f;
	private float currentRotation = 90.0f;


	void Start () {
		mecanimControl = gameObject.GetComponent<MecanimControl>();
	}


	void OnGUI(){
		GUILayout.Label("Speed ("+ animSpeed +")");
		animSpeed = GUILayout.HorizontalSlider (animSpeed, 0, 10f);
		mecanimControl.SetSpeed(animSpeed);

		GUILayout.Label("Rotation ("+ currentRotation +")");
		currentRotation = GUILayout.HorizontalSlider(currentRotation, 0.0f,  360.0f);
		transform.localEulerAngles = new Vector3(0.0f, currentRotation, 0.0f);
		
		GUILayout.Label("Blending ("+ blendDuration +")");
		blendDuration = GUILayout.HorizontalSlider (blendDuration, 0, 1f);
		mecanimControl.defaultTransitionDuration = blendDuration;
		
		GUILayout.Space(10);

		if (GUILayout.Button("Mirror "+ mirror)) {
			mirror = !mirror;
			mecanimControl.SetMirror(mirror);
		}

		if (GUILayout.Button("Debug "+ mecanimControl.debugMode)) {
			mecanimControl.debugMode = !mecanimControl.debugMode;
		}

		GUILayout.Space(10);

		foreach(AnimationData animationData in mecanimControl.animations){
			if (GUILayout.Button(animationData.clipName)){
				mecanimControl.Play(animationData, mirror);
			}
		}
	}
}
