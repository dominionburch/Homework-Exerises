using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using creatingmovies.Models;


namespace creatingmovies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        Movies mymovies = new Movies();


        [Route("GetAllMovies")]
        public Shows[] GetAllMovies()
        {
            return mymovies.movies.ToArray();
        }







        [Route("GetCategory")]
        public Shows[] GetCategory(string cat)
        {
            List<Shows> tempMovieList = new List<Shows>();

            foreach(var movie in mymovies.movies)
            {
                if(movie.Category.Equals(cat, StringComparison.CurrentCultureIgnoreCase))
                {
                    tempMovieList.Add(movie);
                }
            }

            if(tempMovieList == null)
            {
                throw new Exception($"{cat} is not a valid category");
            }
            else
            {
                return tempMovieList.ToArray();
            }
        }

        [Route("GetRandomMovie")]
        public Shows GetRandomMovie()
        {
            Random random = new Random();
            int pick = random.Next(0, mymovies.movies.Count()-1);

            return mymovies.movies[pick];
        }

        [Route("GetRandomCategory")]
        public Shows GetRandomCategory(string category)
        {
            Random rand = new Random();          
            List<Shows> tempMovieList = new List<Shows>();
            int randomShow;

            foreach (var movie in mymovies.movies)
            {
                if (movie.Category.Equals(category, StringComparison.CurrentCultureIgnoreCase))
                {
                    tempMovieList.Add(movie);
                }
            }

            if (tempMovieList.Count() > 0)
            {
                randomShow = rand.Next(0, tempMovieList.Count() - 1);
                return tempMovieList[randomShow];
            }
            else if(tempMovieList.Count() == 0)
            {
                return tempMovieList[0];
            }

            return null;
        }

        [Route("GetRandomShows")]

        public Shows[] GetRandomShows(int quantity)
        {
            List<Shows> randomMovieList = new List<Shows>();
            Random rand = new Random(); 
            //int randomNumber = rand.Next(1, quantity);

            for(int counter = 0; counter < quantity; counter++)
            {
                int randomNumber = rand.Next(1, quantity);
                randomMovieList.Add(mymovies.movies[randomNumber]);
            }

            return randomMovieList.ToArray();
        }




        [Route("GetAllMovieCategories")]
        public string[] GetAllMovieCategories()
        {
            List<string> categories = new List<string>();

            for(int num = 0; num < mymovies.movies.Count(); num++)
            {
                if (!categories.Contains(mymovies.movies[num].Category))
                    categories.Add(mymovies.movies[num].Category);
            }

            return categories.ToArray(); 
        }


        [Route("GetDescription")]
        public string GetDescription(string title)
        {
            string description = "";

            foreach(var show in mymovies.movies)
            {
                if(show.Title.Equals(title, StringComparison.CurrentCultureIgnoreCase))
                    description = show.Description;
                break;
            }

            return description;
        }

    }
}