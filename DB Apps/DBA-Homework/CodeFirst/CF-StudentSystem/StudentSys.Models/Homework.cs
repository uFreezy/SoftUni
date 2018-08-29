using System;

namespace StudentSys.Models
{
    public class Homework
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime SubmissionDate { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

       //Homework: id, content, content-type (e.g. application/pdf or application/zip), submission date 
    }
}