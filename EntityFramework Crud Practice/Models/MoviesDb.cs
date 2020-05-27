using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework_Crud_Practice.Models
{
    public partial class MoviesDb
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public int? RunTime { get; set; }
        public string RentPrice { get; set; }
    }
}
