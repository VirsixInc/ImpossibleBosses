using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(FollowCamera))]
public class FollowCameraEditor : Editor {

	public override void OnInspectorGUI() {
		serializedObject.Update();
		DrawDefaultInspector();

		FollowCamera followCamera = (FollowCamera)target;

		switch (followCamera.m_cameraType) {
		case FollowCamera.CameraType.Fixed:
			break;
		case FollowCamera.CameraType.Free:

			break;
		case FollowCamera.CameraType.Dynamic:
			EditorGUILayout.PropertyField(serializedObject.FindProperty("m_maxMoveDistance"));
			break;
		}

		serializedObject.ApplyModifiedProperties();
	}
}
