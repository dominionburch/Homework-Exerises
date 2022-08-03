namespace creatingmovies.Models
{
    public class Movies
    {
        public List<Shows> movies { get; set; }

        public Movies()
        {
            movies = new List<Shows>()
            {
                new Shows("DragonBall Super", 2012, "Anime", "Goku and Vegeta face a new enemy"),
                new Shows("Inception", 2010, "Sci Fi", "A father does the impossible to be with his children. "),
                new Shows("Thor Love and Thunder", 2022, "Adventure", "A god killer is loose. Thor gets help from another Thor"),
                new Shows("The Phantom Menace", 1998, "Sci Fi", "The tale of Obi Wan Kenobi padawan years and the beginning of Darth Vader"),
                new Shows("Sword of the Stranger", 2012, "Anime", "A wayward ronin runs into skilled chinese swordsmen. Who wins"),
                new Shows("A Space Odessy", 1975, "Sci Fi", "AI help man space travel. Now AI is trapping them in space"),
                new Shows("Jack Reacher", 2001, "Action", "An MP finds himself suddenly wrapped up in a murder conspiracy. Now he has to find himself out of it"),
                new Shows("The Guyver", 1986, "Sci Fi", "A student stumbles upon a device as it attaches to him. Now he has to fight off monsters"),
            };
        }

    }
}
