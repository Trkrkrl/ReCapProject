using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Helpers.FilerHelper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FilerHelper
{
    public class FileHelperManager : IFileHelper
    {
        public void Delete(string filePath)
        {
            throw new NotImplementedException();
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            throw new NotImplementedException();
        }

        public string Upload(IFormFile file, string root)
        {
            throw new NotImplementedException();
        }
    }
}
