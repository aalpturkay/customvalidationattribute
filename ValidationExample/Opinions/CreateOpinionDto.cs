namespace ValidationExample.Opinions;

public class CreateOpinionDto
{
    [MustNotContains(new []{"bad", "word"})]
    public required string Opinion { get; set; }
}