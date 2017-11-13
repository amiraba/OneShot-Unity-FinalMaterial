using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

/// <summary>
/// ExampleMainAbsolutePath support only Mobile
/// </summary>
public class ExampleMainAbsolutePath : MonoBehaviour
{
	IEnumerator _CroutineDownloadMoive()
	{
		this._canLoad = false;
		this._downloading = true;

		//ogg format does not support mobile, you must change url to your video file download url(mp4)
		string url = "http://www.unity3d.com/webplayers/Movie/sample.ogg";
		WWW www = new WWW(url);
		
		while (false == www.isDone )
		{
			this._progress = www.progress;
			yield return null;
		}

		this._absolutPath = Application.persistentDataPath + "/SampleMovie.ogg";
		using (FileStream stream = new FileStream(this._absolutPath, FileMode.Create))
		{
			stream.Write(www.bytes, 0, www.bytes.Length);
			stream.Flush();
			stream.Close();
			Debug.Log(string.Format("Created File {0}", this._absolutPath));
		}

		this._canLoad = true;
		this._downloading = false;
	}
	void LoadAsync()
	{
		//movieTexture.LoadAsync("Example/SampleMovie.mp4", HandleOnLoadCompleted);
		//movieTexture.LoadAsync(HandleOnLoadCompleted);
		movieTexture.LoadAsyncAtAbsolutePath(this._absolutPath, HandleOnLoadCompleted);
	}
	void HandleOnLoadCompleted(SPlugins.MovieTexture.AbstractMovieTextureComponent.ResultType resultType_, 
		string resultDescription_)
	{
		if (SPlugins.MovieTexture.AbstractMovieTextureComponent.ResultType.SUCCESS == resultType_)
		{
			this._canPlay = true;
		}
		else
		{
			Debug.LogError(string.Format("Result:{0} - {1}", resultType_.ToString(), resultDescription_));
		}
	}
	void Play()
	{
		movieTexture.Play(HandleOnPlayCompleted);
	}
	void HandleOnPlayCompleted(SPlugins.MovieTexture.AbstractMovieTextureComponent.CompletedType completedType_)
	{
		this._canPlay = false;
		if (SPlugins.MovieTexture.AbstractMovieTextureComponent.CompletedType.PLAYBACK_COMPLETION == completedType_)
		{
			if (null != movieTexture)
			{
				movieTexture.Stop();
			}
		}
	}
	void Stop()
	{
		movieTexture.Stop();
	}
	void Pause()
	{
		movieTexture.Pause();
	}
	void Resume()
	{
		movieTexture.Resume();
	}
	void SeekTo(int seekToMillisecondTime)
	{
		movieTexture.SeekTo(seekToMillisecondTime);
	}
	void SetLooping(bool loop)
	{
		movieTexture.SetLooping(loop);
	}
	void SetVolume(float normalizedVolume)
	{
		movieTexture.SetVolume(normalizedVolume);
	}
	void Enable3DSound(bool enable)
	{
		movieTexture.Enable3DSound(enable);
	}
	void Set3DSoundMinDistance(float distance)
	{
		movieTexture.Set3DSoundMinDistance(distance);
	}
	void Set3DSoundMaxDistance(float distance)
	{
		movieTexture.Set3DSoundMaxDistance(distance);
	}
	void OnGUI()
	{
		GUILayout.BeginHorizontal();
		GUILayout.BeginVertical();

		if (null != movieTexture )
		{
			GUILayout.Space(20);

			if (true == GUILayout.Button("Download", GUILayout.Height(50)))
			{
				base.StartCoroutine(this._CroutineDownloadMoive());
			}

			if( true == this._downloading )
			{
				GUILayout.Label(string.Format("Downloading {0}", this._progress * 100f));
			}
			if (true == this._canLoad )
			{
				if (true == GUILayout.Button("Load", GUILayout.Height(50)))
				{
					this._canPlay = false;
					this.LoadAsync();
					this.SetVolume(1f);
					this.SetLooping(true);
				}
			}
			

			if (true == this._canPlay )
			{
				if (true == GUILayout.Button("Play", GUILayout.Height(50)))
				{
					this.Play();
					//this.Set3DSoundMinDistance(0);
					//this.Set3DSoundMaxDistance(10000);
					//this.Enable3DSound(true);
				}
				if (true == GUILayout.Button("Stop", GUILayout.Height(50)))
				{
					this.Stop();
				}

				if (true == movieTexture.IsPlaying() )
				{
					if (true == GUILayout.Button("Pause", GUILayout.Height(50)))
					{
						this.Pause();
					}
				}
				if (true == movieTexture.IsPaused())
				{
					if (true == GUILayout.Button("Resume", GUILayout.Height(50)))
					{
						this.Resume();
					}
				}

				GUILayout.BeginHorizontal();
				string seekTimeString = _seekTimeMS.ToString();
				seekTimeString = GUILayout.TextField(seekTimeString, GUILayout.Height(50));
				int.TryParse(seekTimeString, out _seekTimeMS);
				if (true == GUILayout.Button("SeekTo", GUILayout.Height(50)))
				{
					movieTexture.SeekTo(_seekTimeMS);
				}
				GUILayout.EndHorizontal();

				GUILayout.BeginHorizontal();
				this._volumeString = GUILayout.TextField(this._volumeString, GUILayout.Height(50));
				if (true == GUILayout.Button("ChangeVolume", GUILayout.Height(50)))
				{
					float normalizeVolume = 0f;
					float.TryParse(this._volumeString, out normalizeVolume);
					movieTexture.SetVolume(normalizeVolume);
				}
				GUILayout.EndHorizontal();
			}
			

			//GUILayout.BeginHorizontal();
			//GUILayout.Label("Duration :", GUILayout.Height(50));
			//GUILayout.Label(movieTexture.GetDuration().ToString(), GUILayout.Height(50));
			//GUILayout.EndHorizontal();

			//GUILayout.BeginHorizontal();
			//GUILayout.Label("CurrentPosition :", GUILayout.Height(50));
			//GUILayout.Label(movieTexture.GetCurrentPosition().ToString(), GUILayout.Height(50));
			//GUILayout.EndHorizontal();

			
		}
		GUILayout.EndVertical();
		
		GUILayout.EndHorizontal();
	}

	public SPluginsMovieTexture movieTexture = null;
	private bool _canPlay = false;
	private bool _canLoad = false;
	private int _seekTimeMS = 0;
	private string _volumeString = string.Empty;
	private string _absolutPath = string.Empty;
	private float _progress = 0f;
	private bool _downloading = false;
}
