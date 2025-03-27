using DesignPatterns.Structural_patterns.Implementations;
using DesignPatterns.Structural_patterns.Interfaces;


namespace DesignPatterns
{
	// для решения проблемы создаём класс-адаптер который реализует IVideo
	// и в методе Play перенаправляем вызов на метод нужного класса Audio
	// 
	public class AdapterSolution : IExecutor
	{
		public void Execute()
		{
			RecordPlayerSolution recordPlayer = new RecordPlayerSolution();
			AudioPlayer audioPlayer = new AudioPlayer();
			VideoPlayer videoPlayer = new VideoPlayer();

			recordPlayer.Play(videoPlayer);

			//recordPlayer.Play(audioPlayer);

			IVideoPlayer audioAdapter = new AudioToVideoAdapter(audioPlayer);

			recordPlayer.Play(audioAdapter);

		}
	}

	public class RecordPlayerSolution
	{
		public void Play(IVideoPlayer player)
		{
			player.PlayVideo();
		}
	}
}
