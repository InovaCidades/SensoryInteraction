using UnityEngine;
using System.Collections;

public class RealSense : MonoBehaviour {

	private PXCUPipeline pipe;
	private PXCUPipeline.Mode   mode=PXCUPipeline.Mode.GESTURE;
	private PXCMGesture.GeoNode ndata;
	private PXCMGesture.GeoNode.Label bodyLabel = PXCMGesture.GeoNode.Label.LABEL_BODY_HAND_PRIMARY; 
	private PXCMGesture.GeoNode.Label handLabel = PXCMGesture.GeoNode.Label.LABEL_HAND_MIDDLE;

	void Start () 
	{
		pipe = new PXCUPipeline(); 
		if (!pipe.Init(mode)) 
		{
			print("Unable to initialize gesture mode");
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
			float positionX = ndata.positionWorld.x;
			float positionY = ndata.positionWorld.y;
			float positionZ = ndata.positionWorld.z;

			rigidbody2D.position = new Vector3 (positionX, positionY, positionZ);
		}
		
		pipe.ReleaseFrame();   
	}

	void OnDisable() 
	{
		pipe.Close();
		pipe.Dispose ();
	}
}
