using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

//[ExecuteInEditMode]
public class FollowCamera : MonoBehaviour {

	public enum CameraType {
		Fixed, Dynamic, Free
	}
	
	public Transform m_target;
	public Vector3 m_offset;
	public CameraType m_cameraType;

	[HideInInspector]
	public float m_moveSpeed;
	[HideInInspector]
	public float m_maxMoveDistance;

//	#if UNITY_STANDALONE_WIN
//	[DllImport("user32.dll")]
//	static extern bool ClipCursor(ref RECT lpRect);
//	
//	public struct RECT
//	{
//		public int Left;
//		public int Top;
//		public int Right;
//		public int Bottom;
//	}
//	#endif

	void Start () {
//		RECT cursorLimits;
//		cursorLimits.Left   = 0;
//		cursorLimits.Top    = 0;
//		cursorLimits.Right  = Screen.width  - 1;
//		cursorLimits.Bottom = Screen.height - 1;
//		ClipCursor(ref cursorLimits);

		switch (m_cameraType) {
		case CameraType.Dynamic:
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
			break;
		case CameraType.Fixed:
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			break;
		case CameraType.Free:
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
			break;
		}
	}

	void Update () {
		switch (m_cameraType) {
		case CameraType.Dynamic:
			transform.position = m_target.position + m_offset;
			transform.LookAt(m_target);

			Vector3 offset = new Vector3((Input.mousePosition.x - Screen.width/2f)/Screen.width, 0f, (Input.mousePosition.y - Screen.height/2f)/Screen.height);
			offset *= m_maxMoveDistance;

			transform.position += offset;

			break;
		case CameraType.Fixed:
			transform.position = m_target.position + m_offset;
			transform.LookAt(m_target);
			break;
		case CameraType.Free:
			if(Input.GetButton("Jump")) {
				transform.position = m_target.position + m_offset;
				transform.LookAt(m_target);
			} else {

			}
			break;
		}
	}

	public void SetDynamic() {
		m_cameraType = CameraType.Dynamic;
	}

	public void SetFixed() {
		m_cameraType = CameraType.Fixed;
	}

	public void SetFree() {
		m_cameraType = CameraType.Free;
	}
}
