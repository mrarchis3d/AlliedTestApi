﻿namespace Domain.Entities;

public class Movie: BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int Year { get; set; }
    public Image PosterImage { get; set; }
}
