using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComicBookGalleryModel.Models
{
    public class ComicBook
    {
        public ComicBook()
        {
            Artists = new List<ComicBookArtist>();
        }

        //Alternative Primary Key names = ID, ClassNameId, or ClassNameID. Pick one format and be consistent.
        public int Id { get; set; }
        public int SeriesRefId { get; set; }

        //[ForeignKey("SeriesRefId")]
        public Series Series { get; set; }
        public int IssueNumber { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public decimal? AverageRating { get; set; }

        public ICollection<ComicBookArtist> Artists { get; set; }

        public string DisplayText
        {
            get
            {
                return $"{Series?.Title} # {IssueNumber}";
            }
        }

        public void AddArtist(Artist artist, Role role)
        {
            Artists.Add(new ComicBookArtist()
            {
                Artist = artist,
                Role = role
            });
        }
    }
}
