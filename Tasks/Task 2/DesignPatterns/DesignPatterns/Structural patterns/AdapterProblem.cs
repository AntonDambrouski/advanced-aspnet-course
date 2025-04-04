using DesignPatterns.Structural_patterns.Implementations;
using DesignPatterns.Structural_patterns.Interfaces;


namespace DesignPatterns.Structural_patterns
{
	// Изначально RecordPlayer умел работать только с Video 
	// если понадобится дать ему возможно работать с Audio, реализация которого уже есть
	// то для этого понадобится лезть в клас RecordPlayer и делать перегрузку для метода Play()
	// что не всегда может быть возможно
	public class AdapterProblem : IExecutor
	{
		public void Execute()
		{
			AudioPlayer audioPlayer = new AudioPlayer();
			VideoPlayer videoPlayer = new VideoPlayer();
			RecordPlayerProblem recordPlayer = new RecordPlayerProblem();

			recordPlayer.Play(audioPlayer);
			recordPlayer.Play(videoPlayer);


			
		}
	}

	public class RecordPlayerProblem
	{
		public void Play(IVideoPlayer videoPlayer)
		{
			videoPlayer.PlayVideo();
		}

		public void Play(IAudioPlayer audioPlayer)
		{
			audioPlayer.PlayAudio();
		}
	}
}
