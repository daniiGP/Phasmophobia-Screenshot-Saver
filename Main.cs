using MelonLoader;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;
using System.IO;
using System.Security.Cryptography;
using System.Net.Http;

namespace ScreenshotSaver
{
    public class Main : MelonMod
    {
        public static string path = @"C:\Program Files (x86)\Steam\steamapps\common\Phasmophobia";
        List<string> fileIds = new List<string>();
        private bool isInMenu = false;

        private void WaitSeconds()
        {
            System.Threading.Thread.Sleep(5000);
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if(sceneName != "Menu_New")
            {
                CheckFunction();
            } 
            else
            {
                isInMenu = true;
            }
        }

        private void CheckFunction()
        {
            for (; ; )
            {
                if (isInMenu)
                {
                    break;
                }
                for (int i = 0; i < 6; i++)
                {
                    string photoPath = path + "SavedScreen" + i + ".png";
                    bool exist = false;
                    if (File.Exists(photoPath))
                    {
                        string id = getFileId(photoPath);
                        for (int j = 0; j < fileIds.Count; j++)
                        {
                            if (fileIds[j] == id)
                            {
                                exist = true;
                            }
                            else
                            {
                                exist = false;
                                fileIds.Add(id);
                            }
                        }
                        getFileId(photoPath);
                    }
                    if (!exist)
                    {
                        sendFileDiscord(photoPath);
                    }
                }
                WaitSeconds();
            }
        }

        private string getFileId(string filePath)
        {
            using (FileStream stream = File.OpenRead(filePath))
            {
                SHA256Managed sha = new SHA256Managed();
                byte[] checksum = sha.ComputeHash(stream);
                return BitConverter.ToString(checksum).Replace("-", String.Empty);
            }
        }

        private bool sendFileDiscord(string photoPath)
        {
            string id = getFileId(photoPath);
            for(int i = 0; i < fileIds.Count; i++)
            {
                if (fileIds[i] == id)
                {
                    fileIds.RemoveAt(i);
                    HttpClient client = new HttpClient();
                    MultipartFormDataContent content = new MultipartFormDataContent();

                    var file = File.ReadAllBytes(photoPath);
                    content.Add(new ByteArrayContent(file, 0, file.Length), Path.GetExtension(photoPath), photoPath);
                    client.PostAsync("https://discord.com/api/webhooks/985326562624831500/miaJQ0cJskRivUJaFwu_Umfx6rVVmuLeweaeNK3_9cgLJ1gqukYKDLY0xQznEBmiJYP6", content).Wait();
                    client.Dispose();
                }
            }
            return true;
        }
    }
}
