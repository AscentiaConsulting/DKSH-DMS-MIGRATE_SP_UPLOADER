using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SharePoint.Client;

namespace SP_Uploader
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void CreateDocumentLibrary(string doclibName)
        {
            string url = tbSharePointURL.Text;
            string username = "dms_admin.th@dksh.com";
            string password = "Dksh1234";
            OfficeDevPnP.Core.AuthenticationManager authMgr = new OfficeDevPnP.Core.AuthenticationManager();
            var docLib = new ListCreationInformation()
            {
                Title = doclibName,
                Description = "system created document Library for storing DKSH documents",
                TemplateType = 101 //document library
            };
            using (var ctx = authMgr.GetSharePointOnlineAuthenticatedContextTenant(url, username, password))
            {
                if (!ctx.Site.RootWeb.ListExists(doclibName))
                {
                    ctx.Web.Lists.Add(docLib);
                    ctx.ExecuteQuery();
                }
            }
        }
        private void btCheckSource_Click(object sender, EventArgs e)
        {
            using (SourceEntities db = new SourceEntities())
            {
                List<UPLOADER> list = db.UPLOADERs.Where(item => item.PROCESS_FLAG == true && item.FILEPATH != null && item.FILEPATH != "").ToList();
                tbResult.Text += string.Format("Total valid records for processing: {0}\r\n", list.Count);
            }
        }
        public string UploadDocuments(string filePath)
        {
            try
            {
                string url = tbSharePointURL.Text;
                string username = "dms_admin.th@dksh.com";
                string password = "Dksh1234";
                string docLib = tbDocLib.Text;
                // CreateDocumentLibrary(docLib);
                //CreateFolderinDocumentLibrary(docLib, processID);
                //string serverRelativeURL = string.Format("{0}/{1}", docLib, processID);
                OfficeDevPnP.Core.AuthenticationManager authMgr = new OfficeDevPnP.Core.AuthenticationManager();
                string fileName = Path.GetFileName(filePath);
                using (var ctx = authMgr.GetSharePointOnlineAuthenticatedContextTenant(url, username, password))
                {
                    Folder folder = ctx.Web.GetFolderByServerRelativeUrl(docLib);
                    folder.UploadFile(fileName, filePath, true);
                }
                return string.Format("{0}/{1}/{2}", url, docLib, fileName);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            CreateDocumentLibrary(tbDocLib.Text);
            tbResult.Text = ">>Start process.\r\n";
            bool isconnect = CheckConnection();
            using (SourceEntities db = new SourceEntities())
            {
                List<UPLOADER> list = db.UPLOADERs.Where(item => item.PROCESS_FLAG == true && item.FILEPATH != null && item.FILEPATH != "").ToList();
                tbResult.Text += string.Format("Total valid records for processing: {0}\r\n", list.Count);
                foreach (UPLOADER file in list)
                {
                    string result = UploadDocuments(file.FILEPATH);
                    bool success = false;
                    if (result.StartsWith("https"))
                    {
                        file.PROCESS_FLAG = false;
                        file.PROCESSEDTIME = DateTime.Now;
                        file.RESULT = "OK";
                        file.UPLOADEDURL = result;
                        tbResult.Text += string.Format("DocID: {0}, success\r\n", file.DOCID);
                        success = true;
                    }
                    else
                    {
                        file.RESULT = "ERROR";
                        file.ERRORMESSAGE = result;
                        tbResult.Text += string.Format("DocID: {0}, fail\r\n", file.DOCID);
                    }
                    db.SaveChanges();
                    if (success && isconnect)
                    {
                        using (DestinationEntities db2 = new DestinationEntities())
                        {
                            T_STG_DOC doc = db2.T_STG_DOC.FirstOrDefault(item => item.DocID == file.DOCID);
                            if (doc != null)
                            {
                                doc.DOCURL = file.UPLOADEDURL;
                                file.ISUPDATEDSTAGING = true;
                                file.STAGINGUPDATEDTIME = DateTime.Now;
                            }
                            else
                            {
                                file.ERRORMESSAGE = "cannot find record to update";
                            }
                            db.SaveChanges();
                            db2.SaveChanges();
                        }
                    }
                }
            }
            tbResult.Text += ">>Finish process.\n";
        }
        public bool CheckConnection()
        {
            try
            {
                using (DestinationEntities db2 = new DestinationEntities())
                {
                    T_STG_DOC doc = db2.T_STG_DOC.FirstOrDefault(item => item.DocID == "");
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
