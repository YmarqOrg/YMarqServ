/* Copyright2012 MM

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using PhotoService.DataYmarq;

namespace PhotoService
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class PhotoManager
    {



        public const string USER_DUMMY = "1111111111";


        [WebInvoke(UriTemplate = "LoginAs/{loginId}", Method = "POST")]
        public void LoginAs(string loginId)
        {
            Console.WriteLine("LoginAs: {0}", loginId);
        }

        [WebGet(UriTemplate = "Login/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        public UserYmarq Login(string id)
        {
            string IdDummy = "1111111111";
            UserYmarq y = new UserYmarq();
            if (id == IdDummy)
            {
                y.Email = "eugene_hrvtz@gmail.com";
                y.Id = int.Parse(IdDummy);
            }
            else
            {
                y.Email = "error";
                y.Id = -1;
            }

            return y;
            //string result = y.ToJSON().Replace("\\\\\", "");
            //return result;// try touse wed api and change the model + return the object itself us
        }

        [WebGet(UriTemplate = "GetProducts/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        public List<ItemYmarq> GetProducts(string id)
        {
            string IdDummy = "1111111111";
            List<ItemYmarq> y = new List<ItemYmarq>();
            if (id == IdDummy)
            {
                ItemYmarq a = new ItemYmarq() {
                    Description = "Suzuki Swift",
                    Hashtag="Nice car",
                    Id = "e7b6646b-4718-4abf-8260-73188d395c30",
                    Image="", 
                    PublisherId = "" };
                y.Add(a);
            }
            else
            {
                
            }

            return y;
            //string result = y.ToJSON().Replace("\\\\\", "");
            //return result;// try touse wed api and change the model + return the object itself us
        }

        [WebGet(UriTemplate = "GetPhotos")]
        public PhotoItem[] GetPhotos()
        {
            using (DataAcess data = new DataAcess())
            {
                var photos = data.GetPhotos();
                List<PhotoItem> ret = new List<PhotoItem>();
                foreach (var photo in photos)
                    ret.Add(new PhotoItem() { PhotoID = photo.PhotoID, Name = photo.Name, Description = photo.Description, UploadedOn = photo.DateTime });

                return ret.ToArray();
            }
        }

        [WebInvoke(UriTemplate = "UploadPhoto/{fileName}/{description}", Method = "POST")]
        public void UploadPhoto(string fileName, string description, Stream fileContents)
        {
            byte[] buffer = new byte[32768];
            MemoryStream ms = new MemoryStream();
            int bytesRead, totalBytesRead = 0;
            do
            {
                bytesRead = fileContents.Read(buffer, 0, buffer.Length);
                totalBytesRead += bytesRead;

                ms.Write(buffer, 0, bytesRead);
            } while (bytesRead > 0);

            // Save the photo on database.
            using (DataAcess data = new DataAcess())
            {
                var photo = new Photo() { Name = fileName, Description = description, Data = ms.ToArray(), DateTime = DateTime.UtcNow };
                data.InsertPhoto(photo);
            }

            ms.Close();
            Console.WriteLine("Uploaded file {0} with {1} bytes", fileName, totalBytesRead);
        }

        [WebGet(UriTemplate = "GetLastPhoto", BodyStyle = WebMessageBodyStyle.Bare)]
        public Stream GetLastPhoto()
        {
            using (DataAcess data = new DataAcess())
            {
                // Retrieve the last taken photo.
                var photo = data.GetLastPhoto();
                if (photo != null)
                {
                    MemoryStream ms = new MemoryStream(photo.Data);
                    return ms;
                }
                else
                {
                    return null;
                }
            }
        }

        [WebGet(UriTemplate = "GetPhoto/{id}", BodyStyle = WebMessageBodyStyle.Bare)]
        public Stream GePhoto(string id)
        {
            using (DataAcess data = new DataAcess())
            {
                // Retrieve the last taken photo.
                var photo = data.GetPhoto(int.Parse(id));
                if (photo != null)
                {
                    MemoryStream ms = new MemoryStream(photo.Data);
                    return ms;
                }
                else
                {
                    return null;
                }
            }
        }

        [WebInvoke(UriTemplate = "DeletePhoto/{id}", Method = "DELETE")]
        public void DeletePhoto(string id)
        {
            using (DataAcess data = new DataAcess())
            {
                data.DeletePhoto(int.Parse(id));
            }
        }
    }
}
