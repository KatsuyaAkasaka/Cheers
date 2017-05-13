using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour {
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//
//  Simple Clock Script / Andre "AEG" Bürger / VIS-Games 2012
//
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------

    //-- set start time 00:00
    public static int minutes = 0;
    public static int hour = 10;

	public int passMinutes;
	public int time = 100;

    
    //-- time speed factor
    public float clockSpeed;     // 1.0f = realtime, < 1.0f = slower, > 1.0f = faster
	public GameObject gameClearText;

    //-- internal vars
    int seconds;
    float msecs;
    GameObject pointerSeconds;
    GameObject pointerMinutes;
    GameObject pointerHours;
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
	void Start() {
		pointerSeconds = transform.Find("rotation_axis_pointer_seconds").gameObject;
		pointerMinutes = transform.Find("rotation_axis_pointer_minutes").gameObject;
		pointerHours   = transform.Find("rotation_axis_pointer_hour").gameObject;

		msecs = 0.0f;
    	seconds = 0;
	}
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
	void PassTime(int passtime){
		time = 0;
		passMinutes = passtime;

	}

	void Update() {
		if (hour == 6 && minutes >= 0) {
			gameClearText.SetActive (true);
		}
    //-- calculate time
   		msecs += Time.deltaTime * clockSpeed;
		if (msecs >= 60.0f && passMinutes > time) {

			time++;
			msecs = 0;
			/* seconds++;
        if(seconds >= 60)
        {*/
			// seconds = 0;
			minutes++;
			if (minutes > 60) {
				minutes = 0;
				hour++;
				if (hour >= 24)
					hour = 0;
			}
			//}
		}


    //-- calculate pointer angles
    float rotationMinutes = (360.0f / 60.0f)  * minutes;
    float rotationHours   = ((360.0f / 12.0f) * hour) + ((360.0f / (60.0f * 12.0f)) * minutes);

    //-- draw pointers
    pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
    pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);

}
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------------
}
