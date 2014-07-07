using UnityEngine;
using System.Collections;

public class RealSense : MonoBehaviour {
	
	private PXCUPipeline pipe;
	private PXCUPipeline.Mode   mode = PXCUPipeline.Mode.GESTURE;
	private PXCMGesture.GeoNode ndata;
	private PXCMGesture.GeoNode.Label handLabel = PXCMGesture.GeoNode.Label.LABEL_BODY_HAND_LEFT;
	
	void Start () {
		pipe = new PXCUPipeline(); 
		if (!pipe.Init(mode)) {
			print("Error at gesture recognition.");
			return;
		}
	}
	void Update() {
		if (!pipe.AcquireFrame(false)) 
			return;
		
		if (pipe.QueryGeoNode(handLabel, out ndata)) {
			//Get the standard hand position
			float positionX = ndata.positionWorld.x;
			float positionZ = ndata.positionWorld.z;
			float positionY = ndata.positionWorld.y;
			
			positionZ *= 2;
			positionX *= 2;
			positionY *= 2;

			Vector2 move = new Vector2(-positionX, positionZ);

			// Z = /\
			// X = - > <
			// Y = 
			//rigidbody2D.position = move;

			rigidbody2D.MovePosition(rigidbody2D.position + move);
		}
		
		pipe.ReleaseFrame();   
	}
	
	void OnDisable() {
		pipe.Close();
		pipe.Dispose ();
	}
}
