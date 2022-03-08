using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShareButton : MonoBehaviour
{
	//private string shareMassage;

	public void ClickShare()
    {
		//shareMessage = "You slept for  " + PlayerPrefs.GetInt("Score").ToString() + " minutes:)";

		StartCoroutine(TakeSSAndShare());
    }


	private IEnumerator TakeSSAndShare()
	{
		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

		// To avoid memory leaks
		Destroy(ss);
		if(PlayerPrefs.GetInt("SceneID") == 1)
			new NativeShare().AddFile(filePath).SetSubject("Real Dream").SetText("You slept for " + PlayerPrefs.GetInt("Score").ToString()+" seconds ").Share();
		if(PlayerPrefs.GetInt("SceneID") == 5)
			new NativeShare().AddFile(filePath).SetSubject("Real Dream").SetText("You slept for " + PlayerPrefs.GetInt("BWScore").ToString()+" seconds").Share();
		if(PlayerPrefs.GetInt("SceneID") == 6)
			new NativeShare().AddFile(filePath).SetSubject("Real Dream").SetText("You slept for " + PlayerPrefs.GetInt("HDScore").ToString()+" seconds").Share();
	}
}
