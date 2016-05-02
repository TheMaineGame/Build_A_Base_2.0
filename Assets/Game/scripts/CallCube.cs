using UnityEngine;
using System;

public class CallCube : MonoBehaviour {
    [SerializeField]
    GameObject m_livingQuarters;
    [SerializeField]
    Transform cameraPos;
    [SerializeField]
    LayerMask buildings;
	AudioSource au_BuildPlace;

<<<<<<< HEAD
	void Start()
	{
		au_BuildPlace = (AudioSource)gameObject.AddComponent <AudioSource>();
		AudioClip au_BuildPlaceClip;
		au_BuildPlaceClip = (AudioClip)Resources.Load ("BuildPlace");
		au_BuildPlace.clip = au_BuildPlaceClip;
	}
    public void CubeCall () {
		au_BuildPlace.Play ();
        var pos = new Vector3 (
            Mathf.Round (cameraPos.position.x),
            Mathf.Round (cameraPos.position.y),
            Mathf.Round (cameraPos.position.z)
            );
        var offset = Vector3.zero;
        var buildingBox = m_livingQuarters.GetComponent<BoxCollider> ();
        var buildingSize = m_livingQuarters.GetComponent<BoxCollider> ().size * 0.5f;
        Func<Vector3, bool> check = (Vector3 off) => Physics.CheckBox (
            pos + off + buildingBox.center,
            buildingSize,
            m_livingQuarters.transform.rotation,
            buildings);
        bool intersecting = check (offset);
        var stepVec = Vector3.forward;
        var lenSide = 0;
        while (intersecting) {
            var turnCount = 0;
            while (intersecting && turnCount < 2) {
                var stepCount = 0;
                while (intersecting && stepCount < lenSide) {
                    offset += stepVec;
                    intersecting = check (offset);
                    stepCount++;
=======
    const byte limit = 128;
    static byte count = 0;

    public void CubeCall () {
        if (count < limit) {
            var pos = new Vector3 (
                Mathf.Round (cameraPos.position.x),
                Mathf.Round (cameraPos.position.y),
                Mathf.Round (cameraPos.position.z)
                );
            var offset = Vector3.zero;
            var buildingBox = m_livingQuarters.GetComponent<BoxCollider> ();
            var buildingSize = m_livingQuarters.GetComponent<BoxCollider> ().size * 0.5f;
            Func<Vector3, bool> check = (Vector3 off) => Physics.CheckBox (
                pos + off + buildingBox.center,
                buildingSize,
                m_livingQuarters.transform.rotation,
                buildings);
            bool intersecting = check (offset);
            var stepVec = Vector3.forward;
            var lenSide = 0;
            while (intersecting) {
                var turnCount = 0;
                while (intersecting && turnCount < 2) {
                    var stepCount = 0;
                    while (intersecting && stepCount < lenSide) {
                        offset += stepVec;
                        intersecting = check (offset);
                        stepCount++;
                    }
                    stepVec.Set (stepVec.z, 0, -stepVec.x);
                    turnCount++;
>>>>>>> 61636796bbff934a681ae2a5c13e604ba40d8ec9
                }
                lenSide++;
            }
            var building = Instantiate (m_livingQuarters);
            building.transform.position = pos + offset;
            AstarPath.active.UpdateGraphs(building.GetComponent<BoxCollider>().bounds);
            count++;
        }
    }
}