using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RemainingTimeText: MonoBehaviour
{
	private static int countDownEndSeconds = 0;
	private Text text;
	private static bool shouldShow = false;
	public string remainingTimeText = "Time Remaining:";

	protected void Awake ()
	{
		text = GetComponent <Text> ();
	}

	protected void Start ()
	{
		text.text = remainingTimeText + " " + countDownEndSeconds;
	}

	protected void Update ()
	{
		if (shouldShow) {
			text.text = remainingTimeText + " " + countDownEndSeconds;
		}
	}

	static public void Show (bool show)
	{
		shouldShow = show;
	}

	static public void SetTimeRemaining (int newCountDownEndSeconds)
	{
		countDownEndSeconds = newCountDownEndSeconds;
	}
}