using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {

	const float START_POINT = 3.67608f;
	const float BALANCE_POINT = 6.00546f;
	const float END_POINT = 8.33484f;

	int eventTimer;

	float[] cacheChange={0.00000f,0.00000f,0.00000f,0.00000f,0.00000f};

	string[] arrErrorsTexts = {"летачки цицки брате!","пловечки цицки брате","цицки","дојки","omega"};
	int[] arrErrorsID = {1,3,1,2,4};


	int speed;
	//int slowDown=0;
	//int slowDownPosition=0;
	
	Vector2 FIRST_POS=new Vector2(-6.643648f,0.6072301f);
	Vector2 SECOND_POS=new Vector2(-3.500436f,3.096763f);
	Vector2 THIRD_POS=new Vector2(-1.437621f,-3.003343f);
	Vector2 FORTH_POS=new Vector2(-5.219458f,-3.13107f);
	Vector2 FIFTH_POS=new Vector2(-0.04227972f,0.8681197f);

	public Transform btn1,btn2,btn3,btn4,btn5,sld1,sld2,sld3,sld4,sld5;
	public TextMesh txtSpeed,txtInfo,txtStatus;
	
	Transform[] arrSld;

	// Use this for initialization
	void Start () {
	
		SetTimer ();
		arrSld=new Transform[]{sld1,sld2,sld3,sld4,sld5};

	}

	void SetTimer ()
	{
		eventTimer = (int)Random.Range (0.0f, 1200.0f);
		}

	// Update is called once per frame
	void Update () {
		if (eventTimer == 0) {
						int tmpRandom = (int)Random.Range (0.0f, 4.0f);
						txtInfo.text = arrErrorsTexts [tmpRandom];
			int tmpRanndom2=arrErrorsID [tmpRandom];
			print (tmpRanndom2);
			  cacheChange [tmpRanndom2] += Random.Range (-0.01111f, 0.01111f);
						SetTimer ();
				} else {
			eventTimer--;		
		}




				for (int i = 0; i < cacheChange.Length; i++) 
		{
			float tmpCache=((cacheChange[i]/24) * 10000f) / 10000f;

			if ((arrSld[i].position.x>START_POINT) && (arrSld[i].position.x<END_POINT)){
				//if (i==4){
				//		print(cacheChange[i]);
				//}
				arrSld[i].position=new Vector2(arrSld[i].position.x + tmpCache,arrSld[i].position.y);
				cacheChange[i]-=tmpCache;
			}
		}
	}

	private Vector2[] RemoveIndices(Vector2[] IndicesArray, int RemoveAt)
	{
		Vector2[] newIndicesArray = new Vector2[IndicesArray.Length - 1];
		
		int i = 0;
		int j = 0;
		while (i < IndicesArray.Length)
		{
			if (i != RemoveAt)
			{
				newIndicesArray[j] = IndicesArray[i];
				j++;
			}
			
			i++;
		}
		
		return newIndicesArray;
	}


	void ShiftButtons()
	{
		Vector2 [] arrayOfPositions =new Vector2[]{FIRST_POS,SECOND_POS,THIRD_POS,FORTH_POS,FIFTH_POS}; 
		
		Transform [] arrayOfButtons =new Transform[]{btn1,btn2,btn3,btn4,btn5}; 
		
		int startCount = arrayOfPositions.Length;
		
		for(int i = 0; i < startCount; i++)
		{
			int tmpRandom=Random.Range(0,arrayOfPositions.Length);
			
			arrayOfButtons[i].position=arrayOfPositions[tmpRandom];
			
			arrayOfPositions=RemoveIndices(arrayOfPositions,tmpRandom);
			
		}

   }


	void OnMouseDown()
	{ 
		float theChance = Random.Range (0.0f, 11.0f);
		if (theChance > 7.77) {
		  int slowDown=Random.Range(50,7000);
		  int speed=int.Parse(txtSpeed.text)-slowDown;
		  txtSpeed.text=speed.ToString();
		}
	
		switch (this.tag)
		{
		case "5":
		
			float diff5=(BALANCE_POINT-sld5.position.x);
			cacheChange[4]=diff5;
			cacheChange[1]+=-diff5;
			cacheChange[3]+=+diff5;
			print (cacheChange[4]);
			break;
		case "4":

			float diff4=(BALANCE_POINT-sld4.position.x);
			cacheChange[3]=diff4;
			cacheChange[0]+=-diff4;
			cacheChange[2]+=diff4;
		
			break;
		case "3":

			float diff3=(BALANCE_POINT-sld3.position.x);
			cacheChange[2]=diff3;
			cacheChange[1]+=diff3;
			cacheChange[4]+=-diff3;

			break;
		case "2":

			float diff2=(BALANCE_POINT-sld2.position.x);
			cacheChange[1]=diff2;
			cacheChange[3]+=-diff2;
			cacheChange[0]+=+diff2;
			break;
		case "1":

			float diff=(BALANCE_POINT-sld1.position.x);
			cacheChange[0]=diff;
			cacheChange[2]+=-diff;
			cacheChange[4]+=diff;
			break;
		default:
		    break;
		}

	

		ShiftButtons ();

	}

}
