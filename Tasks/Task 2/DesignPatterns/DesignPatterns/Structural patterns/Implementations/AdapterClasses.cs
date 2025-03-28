using DesignPatterns.Structural_patterns.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural_patterns.Interfaces
{

	public class VideoPlayer : IVideoPlayer
	{
		public void PlayVideo()
		{
			Console.WriteLine("Play Video");
		}
	}

	public class AudioPlayer : IAudioPlayer
	{
		public void PlayAudio()
		{
			Console.WriteLine("Play Audio");
		}
	}

	public class AudioToVideoAdapter : IVideoPlayer
	{
		AudioPlayer audioPlayer;
		public AudioToVideoAdapter(AudioPlayer player)
		{
			audioPlayer = player;
		}
		public void PlayVideo()
		{
			audioPlayer.PlayAudio();
		}
	}

	

}
