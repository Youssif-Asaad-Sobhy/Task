using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPA.Entities;

namespace MPA.DTOs
{
    public class NewsListDTO
    {
        public List<ArchiveDataDTO> ArchiveData { get; set; }
        public List<News> NewsItems { get; set; }
    }
}
