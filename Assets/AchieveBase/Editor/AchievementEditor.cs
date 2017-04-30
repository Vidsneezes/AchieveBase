using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AchievementEditor : EditorWindow {

    [MenuItem("AchieveBase/Achievement Editor")]
    public static void Init()
    {
        AchievementEditor ae = (AchievementEditor)EditorWindow.GetWindow(typeof(AchievementEditor));
        ae.Show();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
