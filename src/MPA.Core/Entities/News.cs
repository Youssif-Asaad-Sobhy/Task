using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace MPA.Entities
{
    [Table("News")]
    public class News : Entity, IHasCreationTime
    {
        public DateTime CreationTime { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string PhotoPath { get; set; }
    }
}
