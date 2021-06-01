namespace ServiceLayer.Models
{
    using System;

    public class NewsData
    {
        public string Id { get; set; }
        public DateTime WebPublicationDate { get; set; }
        public string WebTitle { get; set; }
        public string WebUrl { get; set; }
    }
}
