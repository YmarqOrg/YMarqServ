using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoService.DataYmarq
{
    public class ItemYmarq
    {
        //[{"Id":"e7b6646b-4718-4abf-8260-73188d395c30","PublisherId":1111111111,"Hashtag":"Suzuki Swift","Description":"Nice car","Image":""}]
        public string Id { get; set; }
        public string PublisherId { get; set; }

        public string Hashtag { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }
    }
}