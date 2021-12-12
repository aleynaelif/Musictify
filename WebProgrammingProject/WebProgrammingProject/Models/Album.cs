using Microsoft.AspNetCore.Mvc;
using System;

namespace WebProgrammingProject.Models
{
    public class Album
    {
        public string Singer{ get; set; }
        public string Songs{ get; set; } //�o�ul olmal� liste yada array
        public int ReleaseDate { get; set; }
        public double Rate { get; set; }

    }
}
