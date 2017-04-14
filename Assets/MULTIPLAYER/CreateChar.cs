using UnityEngine;
using System.Collections;

public class CreateChar : MonoBehaviour 
{
    public Camera Camera;

    void OnJoinedRoom()
    {
        CreatePlayerObject();
    }

    void CreatePlayerObject()
    {
        Vector3 position = new Vector3(0f, 0f, 0);
        GameObject newPlayerObject = PhotonNetwork.Instantiate( "LOTA_ChrisMP", position, Quaternion.identity, 0 );
        Camera.GetComponent<UnityStandardAssets.Utility.SmoothFollow>().target = newPlayerObject.transform.GetChild(1);
    }
}
