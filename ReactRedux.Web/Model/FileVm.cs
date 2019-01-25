using System;

namespace ReactRedux.Web.Model
{
    public class FileVm
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string MimeType { get; set; }

        public long Size { get; set; }
    }
}