using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingHub2.Model
{
    public class RecenzijaDetaljiVM
    {
        public int ID { get; set; }

        [MaxLength(250)]
        public string Naslov { get; set; }
        public string VideoLink { get; set; }
        public string SlikaLink { get; set; }

        public string Korisnik { get; set; }
        public DateTime? DatumObjaveRecenzije { get; set; }

        [MaxLength(50)]
        public string Naziv { get; set; }
        [MaxLength(50)]
        public string Developer { get; set; }
        [MaxLength(50)]
        public string Izdavac { get; set; }
        public DateTime? DatumIzlaskaIgre { get; set; }

        [MaxLength(20000)]
        public string Sadrzaj { get; set; }
        public List<string> Zarnovi { get; set; }
        public List<string> Konzole { get; set; }
        public class RecenzijaRow
        {
            public int Id { get; set; }
            public string Naslov { get; set; }
            public DateTime? DatumObjaveRecenzije { get; set; }
            public string SlikaLink { get; set; }
        }
        public List<RecenzijaRow> NajnovijeRecenzije { get; set; }
        public string YouTubeId
        {
            get
            {
                string id = null;

                if (!string.IsNullOrEmpty(VideoLink) &&
                   (VideoLink.Contains("youtube.com") || VideoLink.Contains("youtu.be")))
                {
                    int lastIndexOf = VideoLink.LastIndexOf("v=");
                    if (lastIndexOf == 0)
                    {
                        lastIndexOf = VideoLink.LastIndexOf("/") + 1;
                    }
                    else
                    {
                        lastIndexOf += 2;
                    }
                    id = VideoLink.Substring(lastIndexOf);
                }
                return id;
            }
        }
    }
}
