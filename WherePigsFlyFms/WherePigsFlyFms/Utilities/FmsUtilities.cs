﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WherePigsFlyFms.Models;
using WherePigsFlyFms.ViewModels;

namespace WherePigsFlyFms.Utilities
{
    public class FmsUtilities : IFmsUtilities
    {
        public AttachmentModel Upload(HttpPostedFileBase file, FarmViewModel viewModel)
        {
            AttachmentModel model = new AttachmentModel();
            try
            {
                string theFileName = (file.FileName);
                byte[] thePictureAsBytes = new byte[file.ContentLength];
                BinaryReader theReader = new BinaryReader(file.InputStream);

                thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                string base64Data = Convert.ToBase64String(thePictureAsBytes);

                model.AttachmentType = file.FileName;
                model.BaseData = base64Data;
                model.FK_Animal_Id = viewModel.Animal.Id;
            }
            catch (Exception)
            {

               
            }

            return model;
        }
    }
}