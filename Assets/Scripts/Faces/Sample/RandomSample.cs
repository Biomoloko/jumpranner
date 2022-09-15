using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomSample : MonoBehaviour {
	public Image cbody;
	public Image cface;
	public Image chair;
	public Image ckit;
	public Sprite[] body;
	public Sprite[] face;
	public Sprite[] hair;
	public Sprite[] kit;
	public Color[] background;

	public List<string> AllNicks = new List<string>(){"PowerGrab",
													"Tweedlex",
													"HaelSturm",
													"KookSpook",
													"KnifeRing",
													"Octopi",
													"Daybreak",
													"HoltHamlet",
													"CaesarJ",
													"BloodSoul",
													"Valance",
													"Belting",
													"GrimReap",
													"AstroBoy",
													"Oxonomy",
													"Ouster",
													"Archerwell",
													"KnuckleDust",
													"PrincePle",
													"Plover",
													"Megalith",
													"Redshock",
													"HaelSturm",
													"BrunsonDid",
													"HeroIce",
													"Akics",
													"Naracska",
													"KpcoTk",
													"dok",
													"Fishard",
													"Kazulika",
													"Innov",
													"Def",
													"Elenasium",
													"aero",
													"Green",
													"Dymy",
													"filmaxa",
													"Sichag",
													"Vizion" };

	public TextMeshProUGUI nick;



	// Use this for initialization
	void Start () {
		
		cbody.sprite = body[PlayerPrefs.GetInt("avatar_body")];
		cface.sprite = face[PlayerPrefs.GetInt("avatar_face")];
		chair.sprite = hair[PlayerPrefs.GetInt("avatar_hair")];
		ckit.sprite = kit[PlayerPrefs.GetInt("avatar_kit")];

		if (PlayerPrefs.GetString("nick") == "")
			PlayerPrefs.SetString("nick", "Player5032");

		nick.text = PlayerPrefs.GetString("nick");
	}

	public void RandomizeCharacter(){
		//		cbody.sprite = body[0];

		PlayerPrefs.SetInt("avatar_body", Random.Range(0, body.Length) );
		PlayerPrefs.SetInt("avatar_face", Random.Range(0, face.Length));
		PlayerPrefs.SetInt("avatar_hair", Random.Range(0, hair.Length));
		PlayerPrefs.SetInt("avatar_kit", Random.Range(0, kit.Length));


		cbody.sprite = body[PlayerPrefs.GetInt("avatar_body")];
		cface.sprite = face[PlayerPrefs.GetInt("avatar_face")];
		chair.sprite = hair[PlayerPrefs.GetInt("avatar_hair")];
		ckit.sprite = kit[PlayerPrefs.GetInt("avatar_kit")];


		
	}

	public void RandonNick()
    {
		PlayerPrefs.SetString("nick", AllNicks[Random.Range(0, hair.Length)] );

		nick.text = PlayerPrefs.GetString("nick");
	}

}
