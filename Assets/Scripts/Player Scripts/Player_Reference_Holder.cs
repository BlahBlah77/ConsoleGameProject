using UnityEngine;

public class Player_Reference_Holder : MonoBehaviour {

    [Header("References")]
    public Player_Control_Movement playerPCM;
	public Player_Control_Ground_Check playerCGC;
	public Rigidbody rb;
	public Transform camTran;
	public Transform playerObject;
    public Int_Stat_Script playerXP;
    public Int_Stat_Script playerLevel;

    void Start () 
	{
        camTran = Camera.main.transform;
		rb = GetComponent<Rigidbody> ();
		playerCGC = GetComponent<Player_Control_Ground_Check> ();
        playerPCM = GetComponent<Player_Control_Movement>();

    }
}
