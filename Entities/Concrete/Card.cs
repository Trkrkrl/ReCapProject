using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Card:IEntity
    {
        public int CardId { get; set; }
        public int CustomerId { get; set; }
        public string CardNumber { get; set; }
        public int DateMonth { get; set; }//sql de tiny int
        public int DateYear { get; set; }//sql de small int
        public string NameOnTheCard { get; set; }
        public string CvvCode { get; set; }//sql taradında buna nvarchar 5 yeter bence
    }
}
