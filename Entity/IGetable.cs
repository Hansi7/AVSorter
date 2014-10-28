using System;
namespace AVSORTER
{
    public interface IGetable
    {
        bool IsInitCompleted { get; set; }
        bool GetCover(Movie mo);
        Movie GetMovie(MovieBasic basic);
        System.Collections.Generic.List<MovieBasic> Query(string fcode);
    }
}
