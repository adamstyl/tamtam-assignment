namespace Common
{
	public interface IMovie
	{
		string Description { get; }
		string Id { get; }
		string PosterLocation { get; }
		string Title { get; }
		string TrailerUrl { get; }

	}
}