using System.Threading;
using UnityEngine;

public class mSound
{
	private const int INTERVAL = 5;

	private const int MAXTIME = 100;

	private const int MAX_VOLUME = 100;

	public const sbyte MUSIC_LANG = 0;

	public const sbyte MUSIC_THANHPHO = 1;

	public const sbyte MUSIC_THIENNHIEN = 2;

	public const sbyte MUSIC_HANGDONG = 3;

	public const sbyte MUSIC_DAMLAY = 4;

	public const sbyte MUSIC_GIOTHOI = 5;

	public const sbyte MUSIC_BOSS = 6;

	public const sbyte MUSIC_SUOIMA = 7;

	public const sbyte MUSIC_SAMAC = 8;

	public const sbyte MUSIC_PHOBANG = 9;

	public const sbyte SOUND_2KIEM_LV1 = 0;

	public const sbyte SOUND_SUNG_LV1 = 1;

	public const sbyte SOUND_PS_LV1 = 2;

	public const sbyte SOUND_KIEM_LV1 = 3;

	public const sbyte SOUND_KIEM_LV2 = 4;

	public const sbyte SOUND_KIEM_LV3 = 5;

	public const sbyte SOUND_KIEM_LV4 = 6;

	public const sbyte SOUND_2KIEM_LV2 = 7;

	public const sbyte SOUND_2KIEM_LV3_GAIDOC = 8;

	public const sbyte SOUND_2KIEM_LV3_PHANTHAN = 9;

	public const sbyte SOUND_2KIEM_LV4_5KIEM = 10;

	public const sbyte SOUND_2KIEM_LV5_MUADOC = 11;

	public const sbyte SOUND_PS_LV2 = 13;

	public const sbyte SOUND_PS_LV3 = 14;

	public const sbyte SOUND_PS_LV4 = 15;

	public const sbyte SOUND_PS_LV5 = 16;

	public const sbyte SOUND_SUNG_LV2_3VIEN = 12;

	public const sbyte SOUND_SUNG_LV2_DANDIEN = 17;

	public const sbyte SOUND_SUNG_LV3_TENLUA = 18;

	public const sbyte SOUND_SUNG_LV3_LASER = 19;

	public const sbyte SOUND_SUNG_LV4_BAODAN = 20;

	public const sbyte SOUND_SUNG_LV4_SET = 21;

	public const sbyte SOUND_SUNG_LV5_MUASET = 22;

	public const sbyte SOUND_SUNG_LV5_MUATENLUA = 23;

	public const sbyte SOUND_EFF_CUONGHOA1 = 24;

	public const sbyte SOUND_PET_SOI = 25;

	public const sbyte SOUND_EFF_CUONGHOA_OK = 26;

	public const sbyte SOUND_EFF_CUONGHOA_FAIL = 27;

	public const sbyte SOUND_EFF_COIN_GEM = 28;

	public const sbyte SOUND_EFF_SHOW_BOX = 29;

	public const sbyte SOUND_EFF_GONG_BUFF_NU = 30;

	public const sbyte SOUND_EFF_GONG_BUFF_NAM = 31;

	public const sbyte SOUND_EFF_THIENTHACHROI = 32;

	public const sbyte SOUND_EFF_BOSSXUATHIEN = 33;

	public const sbyte SOUND_EFF_BOSS_S_PHONG = 34;

	public const sbyte SOUND_EFF_BOSS_S_NUOC = 35;

	public const sbyte SOUND_EFF_BOSS_S_TOA = 36;

	public const sbyte SOUND_EFF_BOSS_S_LUA = 37;

	public const sbyte SOUND_EFF_BIDANH = 38;

	public const sbyte SOUND_EFF_GIAOTIEP = 39;

	public const sbyte SOUND_EFF_THAYDO = 40;

	public const sbyte SOUND_EFF_CLICK = 41;

	public const sbyte SOUND_EFF_MENU = 42;

	public const sbyte SOUND_EFF_THOREN = 43;

	public const sbyte SOUND_EFF_DAMDONG1 = 44;

	public const sbyte SOUND_EFF_TELE = 45;

	public const sbyte SOUND_EFF_BUOCCHAN = 46;

	public const sbyte SOUND_EFF_MEO = 47;

	public const sbyte SOUND_EFF_GA = 48;

	public const sbyte SOUND_EFF_ECH = 49;

	public const sbyte SOUND_EFF_ECH_TIEP_NUOC = 50;

	public const sbyte SOUND_EFF_PLAYERDINUOC = 51;

	public const sbyte SOUND_EFF_CHUOT = 52;

	public const sbyte SOUND_EFF_DUOCLUA = 53;

	public const sbyte SOUND_EFF_VOIPHUNNUOC = 54;

	public const sbyte SOUND_EFF_NUOCCHAY = 55;

	public const sbyte SOUND_EFF_GIOTNUOC = 56;

	public const sbyte SOUND_PET_BAN_TEN = 57;

	public const sbyte SOUND_EFF_CHAN_NGUA = 58;

	public static bool isEnableSound = true;

	public static int status;

	public static int postem;

	public static int timestart;

	private static string filenametemp;

	private static int volumetem;

	public static bool isSound = true;

	public static bool isNotPlay;

	public static bool stopAll;

	public static AudioSource SoundWater;

	public static AudioSource SoundRun;

	public static AudioSource SoundBGLoop;

	public static int volumeSound = 1;

	public static int volumeMusic = 2;

	public static int[] soundID;

	public static int CurMusic = -1;

	public static bool isMusic = true;

	public static int[] isPlaying;

	public static AudioClip[] music;

	public static GameObject[] player;

	public static string[] fileName = new string[34]
	{
		"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
		"10", "11", "12", "13", "14", "15", "16", "17", "18", "19",
		"29", "21", "22", "23", "24", "25", "26", "27", "28", "29",
		"30", "31", "32", "33"
	};

	public static int l1;

	public static void stop()
	{
		for (int i = 0; i < player.Length; i++)
		{
			if (player[i] != null)
			{
				player[i].GetComponent<AudioSource>().Pause();
			}
		}
	}

	public static bool isPlayingz()
	{
		return false;
	}

	public static void pauseCurMusic()
	{
		for (int i = 0; i < music.Length; i++)
		{
			if (i < l1 && isPlaying[i] == 1)
			{
				isPlaying[i] = 0;
				sTopSoundBG(i);
			}
		}
	}

	public static void init()
	{
		GameObject gameObject = new GameObject();
		gameObject.name = "Audio Player";
		gameObject.transform.position = Vector3.zero;
		gameObject.AddComponent<AudioListener>();
		SoundBGLoop = gameObject.AddComponent<AudioSource>();
	}

	public static void init(int[] musicID, int[] sID)
	{
		if (player == null && music == null)
		{
			init();
			l1 = musicID.Length;
			player = new GameObject[musicID.Length + sID.Length];
			music = new AudioClip[musicID.Length + sID.Length];
			isPlaying = new int[musicID.Length + sID.Length];
			for (int i = 0; i < player.Length; i++)
			{
				string text = ((i >= l1) ? ("/sound/" + (i - l1)) : ("/music/" + i));
				getAssetSoundFile(text, i);
			}
		}
	}

	public static void playSound(int id, int volume)
	{
		if (isSound)
		{
			play(id + l1, volume);
		}
	}

	public static void playSound1(int id, int volume)
	{
		play(id, volume);
	}

	public static void getAssetSoundFile(string fileName, int pos)
	{
		stop(pos);
		string empty = string.Empty;
		empty = Main.res + fileName;
		load(empty, pos);
	}

	public static void stopSoundAll()
	{
		for (int i = 0; i < l1; i++)
		{
			stop(i);
		}
		mSystem.gcc();
	}

	public static void stopAllz()
	{
		for (int i = 0; i < music.Length; i++)
		{
			sTopSoundBG(i);
		}
		for (int j = 0; j < l1; j++)
		{
			stop(j);
		}
	}

	public static void stopAllBg()
	{
		for (int i = 0; i < music.Length; i++)
		{
			stop(i);
		}
		sTopSoundBG(0);
		sTopSoundRun();
		stopSoundNatural(0);
	}

	public static void update()
	{
	}

	public static void stopMusic(int x)
	{
		if (GameCanvas.isPlaySound)
		{
			stop(x);
		}
	}

	public static void play(int id, int volume)
	{
		if (!isNotPlay && GameCanvas.isPlaySound)
		{
			start(volume, id);
		}
	}

	public static void playSoundRun(int id, int volume)
	{
		if (GameCanvas.isPlaySound && !(SoundRun == null))
		{
			SoundRun.GetComponent<AudioSource>().loop = true;
			SoundRun.GetComponent<AudioSource>().clip = music[id];
			SoundRun.GetComponent<AudioSource>().volume = volume;
			SoundRun.GetComponent<AudioSource>().Play();
		}
	}

	public static void sTopSoundRun()
	{
		SoundRun.GetComponent<AudioSource>().Stop();
	}

	public static bool isPlayingSound()
	{
		if (SoundRun == null)
		{
			return false;
		}
		return SoundRun.GetComponent<AudioSource>().isPlaying;
	}

	public static int getMediaSoundFile(string fileName)
	{
		return -1;
	}

	public static void SetLoopSound(int id, int volume, int loop)
	{
	}

	public static void UnSetLoopAll()
	{
	}

	public static void playSoundNatural(int id, int volume, bool isLoop)
	{
		if (GameCanvas.isPlaySound && !(SoundBGLoop == null))
		{
			SoundWater.GetComponent<AudioSource>().loop = isLoop;
			SoundWater.GetComponent<AudioSource>().clip = music[id];
			SoundWater.GetComponent<AudioSource>().volume = volume;
			SoundWater.GetComponent<AudioSource>().Play();
		}
	}

	public static void stopSoundNatural(int id)
	{
		SoundWater.GetComponent<AudioSource>().Stop();
	}

	public static bool isPlayingSoundatural(int id)
	{
		if (SoundWater == null)
		{
			return false;
		}
		return SoundWater.GetComponent<AudioSource>().isPlaying;
	}

	public static void playMus(int type, int vl, bool loop)
	{
		if (type < 0)
		{
			type = 0;
		}
		if (!isNotPlay && isMusic && isPlaying[type] != 1)
		{
			pauseCurMusic();
			isPlaying[type] = 1;
			playSoundBGLoop(type, vl);
		}
	}

	public static void playSoundBGLoop(int id, int volume)
	{
		if (GameCanvas.isPlaySound && !(SoundBGLoop == null) && !isPlayingSoundBG(id))
		{
			SoundBGLoop.GetComponent<AudioSource>().loop = true;
			SoundBGLoop.GetComponent<AudioSource>().clip = music[id];
			SoundBGLoop.GetComponent<AudioSource>().volume = volume;
			SoundBGLoop.GetComponent<AudioSource>().Play();
		}
	}

	public static void sTopSoundBG(int id)
	{
		SoundBGLoop.GetComponent<AudioSource>().Stop();
	}

	public static bool isPlayingSoundBG(int id)
	{
		if (SoundBGLoop == null)
		{
			return false;
		}
		return SoundBGLoop.GetComponent<AudioSource>().isPlaying;
	}

	public static void load(string filename, int pos)
	{
		if (Main.isWindowsPhone)
		{
			__load(filename, pos);
		}
		else if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			__load(filename, pos);
		}
		else
		{
			_load(filename, pos);
		}
	}

	private static void _load(string filename, int pos)
	{
		if (status != 0)
		{
			Cout.LogError("CANNOT LOAD AUDIO " + filename + " WHEN LOADING " + filenametemp);
			return;
		}
		filenametemp = filename;
		postem = pos;
		status = 2;
		int i;
		for (i = 0; i < 100; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 100)
		{
			Cout.LogError("TOO LONG FOR LOAD AUDIO " + filename);
			return;
		}
		Cout.Log("Load Audio " + filename + " done in " + i * 5 + "ms");
	}

	private static void __load(string filename, int pos)
	{
		music[pos] = (AudioClip)Resources.Load(filename, typeof(AudioClip));
		GameObject.Find("Main Camera").AddComponent<AudioSource>();
		player[pos] = GameObject.Find("Main Camera");
	}

	public static void start(int volume, int pos)
	{
		if (Main.isWindowsPhone)
		{
			__start(volume, pos);
		}
		else if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			__start(volume, pos);
		}
		else
		{
			_start(volume, pos);
		}
	}

	public static void _start(int volume, int pos)
	{
		if (status != 0)
		{
			Debug.LogError("CANNOT START AUDIO WHEN STARTING");
			return;
		}
		volumetem = volume;
		postem = pos;
		status = 3;
		int i;
		for (i = 0; i < 100; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 100)
		{
			Debug.LogError("TOO LONG FOR START AUDIO");
		}
		else
		{
			Debug.Log("Start Audio done in " + i * 5 + "ms");
		}
	}

	public static void __start(int volume, int pos)
	{
		if (!(player[pos] == null))
		{
			player[pos].GetComponent<AudioSource>().volume = volume;
			player[pos].GetComponent<AudioSource>().PlayOneShot(music[pos], volume);
		}
	}

	public static void stop(int pos)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			__stop(pos);
		}
		else
		{
			_stop(pos);
		}
	}

	public static void _stop(int pos)
	{
		if (status != 0)
		{
			Debug.LogError("CANNOT STOP AUDIO WHEN STOPPING");
			return;
		}
		postem = pos;
		status = 4;
		int i;
		for (i = 0; i < 100; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 100)
		{
			Debug.LogError("TOO LONG FOR STOP AUDIO");
		}
		else
		{
			Debug.Log("Stop Audio done in " + i * 5 + "ms");
		}
	}

	public static void __stop(int pos)
	{
		if (player[pos] != null)
		{
			player[pos].GetComponent<AudioSource>().Stop();
		}
	}
}
