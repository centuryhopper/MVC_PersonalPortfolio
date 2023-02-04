using Personal_Portfolio.Models;

namespace Personal_Portfolio.Services;


public class ProjectsDataRepository : IProjectsDataRepository<ProjectCardModel>
{
    private List<ProjectCardModel> projects;

    public ProjectsDataRepository()
    {
        projects = new List<ProjectCardModel>()
        {
            new ProjectCardModel(
                "https://raw.githubusercontent.com/leozhang1/leo_personal_website/main_laptop/src/photos/tic_tac_toe.png",
                "Tic Tac Toe",
                "Tic Tac Toe with apples and oranges!",
                "https://gamerboi2022.itch.io/tic-tac-toe",
                "about:blank"
            ),
            new ProjectCardModel(
                "https://raw.githubusercontent.com/leozhang1/leo_personal_website/main_laptop/src/photos/pong.png",
                "Pong",
                "This is Classic game of pong. The ball will move faster with each bounce to make things more interesting. Player 1 controls: W and S. Player 2 controls: up and down arrows. I hope you enjoy.",
                "https://gamerboi2022.itch.io/pong",
                "about:blank"
            ),
        };
    }

    public IEnumerable<ProjectCardModel> GetData()
    {
        return projects.AsEnumerable<ProjectCardModel>();
    }

    public IEnumerable<ProjectCardModel> Search(string searchTerm)
    {
        if (string.IsNullOrEmpty(searchTerm))
        {
            return projects;
        }

        return projects.Where(project => project.title!.ToLower().Contains(searchTerm.ToLower()));
    }
}

