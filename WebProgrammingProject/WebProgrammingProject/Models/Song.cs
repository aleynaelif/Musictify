using Microsoft.AspNetCore.Mvc;
using System;

namespace WebProgrammingProject.Models
{
    public class Song
    {
        public string Name{ get; set; }
        public double MinuteLenght{ get; set; } //�o�ul olmal� liste yada array
        public string Genre { get; set; }
    }
}
