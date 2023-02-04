namespace Personal_Portfolio.Models;



public class BlogModel
{
    public string title;
    public DateTime date;
    public string previewDesc;
    public string routeName;
    public List<VideoUrlModel>? videoUrls;
    public string fullDesc;


    public BlogModel(string title, DateTime date, string previewDesc, string routeName, string fullDesc, List<VideoUrlModel>? videoUrls = null)
    {
        this.title = title;
        this.date = date;
        this.previewDesc = previewDesc;
        this.routeName = routeName;
        this.videoUrls = videoUrls;
        this.fullDesc = fullDesc;
    }

    public override string ToString()
    {
        return $"title: {title}, date: {date}, previewDesc: {previewDesc}, routeName: {routeName},";
    }
}
