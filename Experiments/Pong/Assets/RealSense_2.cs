using UnityEngine;
using System.Collections;

public class RealSense_2 : MonoBehaviour {
	
	private PXCUPipeline pipe;
	private PXCUPipeline.Mode   mode=PXCUPipeline.Mode.GESTURE;
	private PXCMGesture.GeoNode ndata;
	private PXCMGesture.GeoNode.Label bodyLabel = PXCMGesture.GeoNode.Label.LABEL_BODY_HAND_PRIMARY; 
	private PXCMGesture.GeoNode.Label handLabel = PXCMGesture.GeoNode.Label.LABEL_HAND_MIDDLE;
	
	
	float positionZ;
	
	void Start () 
	{
		pipe = new PXCUPipeline(); 
		if (!pipe.Init(mode)) 
		{
			print("Error at gesture recognition.");
			return;
		}
	}
	void Update()
	{
		if (!pipe.AcquireFrame(false)) 
			return;
		
		if (pipe.QueryGeoNode(bodyLabel | handLabel, out ndata))
		{
			//Get the standard hand position
			float positionZ = ndata.positionWorld.z;
			float positionX = ndata.positionWorld.x;
			
			if (positionX < 0) {
				positionZ *= 5;
				
				Vector2 move = new Vector2(0, positionZ);
				rigidbody2D.MovePosition(rigidbody2D.position + move);
			}
		}
		
		pipe.ReleaseFrame();   
	}
	
	void OnDisable() 
	{
		pipe.Close();
		pipe.Dispose ();
	}
}
