using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExampleMainNoneGUIMultiple : MonoBehaviour
{
	private class MovieTextureData
	{
		public SPluginsMovieTexture movieTexture;
		public bool canPlay;
	}
	void Start()
	{
		foreach (SPluginsMovieTexture movieTexture in this.movieTextureList)
		{
			if (null != movieTexture)
			{
				MovieTextureData movieTextureData = new MovieTextureData();
				movieTextureData.movieTexture = movieTexture;
				movieTextureData.canPlay = false;
				movieTextureData.movieTexture.LoadAsync(HandleOnLoadCompleted);
				this._movieTextureDic.Add(movieTextureData.movieTexture.GetUID(), movieTextureData);
			}
		}
	}
	void Update()
	{
		foreach (MovieTextureData movieTextureData in this._movieTextureDic.Values)
		{
			if (null != movieTextureData)
			{
				if (true == movieTextureData.canPlay && false == movieTextureData.movieTexture.IsPlaying())
				{
					movieTextureData.movieTexture.SetVolume(1f);
					movieTextureData.movieTexture.Play(HandleOnPlayCompleted);
					movieTextureData.canPlay = false;
				}
			}
		}
	}
	void OnDestroy()
	{
		foreach (MovieTextureData movieTextureData in this._movieTextureDic.Values)
		{
			if (null != movieTextureData && null != movieTextureData.movieTexture)
			{
				movieTextureData.movieTexture.Stop();
			}
		}
	}
	void HandleOnLoadCompleted(int uid_, SPlugins.MovieTexture.AbstractMovieTextureComponent.ResultType resultType_,
		string resultDescription_)
	{
		MovieTextureData movieTextureData = null;
		if (true == this._movieTextureDic.TryGetValue(uid_, out movieTextureData))
		{
			if (SPlugins.MovieTexture.AbstractMovieTextureComponent.ResultType.SUCCESS == resultType_)
			{
				movieTextureData.canPlay = true;
			}
			else
			{
				Debug.LogError(string.Format("Result:{0} - {1}", resultType_.ToString(), resultDescription_));
			}
		}
	}
	void HandleOnPlayCompleted(int uid_, SPlugins.MovieTexture.AbstractMovieTextureComponent.CompletedType completedType_)
	{
		MovieTextureData movieTextureData = null;
		if (true == this._movieTextureDic.TryGetValue(uid_, out movieTextureData))
		{
			if (SPlugins.MovieTexture.AbstractMovieTextureComponent.CompletedType.PLAYBACK_COMPLETION == completedType_)
			{
				movieTextureData.movieTexture.Stop();
			}
		}
	}

	public List<SPluginsMovieTexture> movieTextureList = new List<SPluginsMovieTexture>();
	private Dictionary<int/*uid*/, MovieTextureData> _movieTextureDic = new Dictionary<int, MovieTextureData>();
}
