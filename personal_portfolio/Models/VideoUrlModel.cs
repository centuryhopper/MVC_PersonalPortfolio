namespace Personal_Portfolio.Models;

public class VideoUrlModel
{
    public string url;
    public string title;

    public VideoUrlModel(string url="", string title="")
    {
        this.url = url;
        this.title = title;
    }

    public override string ToString()
    {
        return $"title: {title}, url: {url}";
    }
}