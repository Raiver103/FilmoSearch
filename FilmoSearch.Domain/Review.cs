﻿namespace FilmoSearch.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }

    }
}
