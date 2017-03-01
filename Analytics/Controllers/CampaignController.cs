﻿using Analytics.Helpers.BO;
using Analytics.Helpers.Utility;
using Analytics.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace Analytics.Controllers
{
    public class CampaignController : Controller
    {
        shortenURLEntities dc = new shortenURLEntities();

        // GET: Campaign
        public JsonResult Index(string id)
        {
            //    return View();
            //}
            //public JsonResult GetclientDetails()
            //{
            List<CampaignView1> objc = new List<CampaignView1>();
            CampaignView1 obj = new CampaignView1();
            int id1 = Convert.ToInt32(id);
            try
            {
                if (id == null && Session["id"] != "")
                {
                    //get all client detials
                    objc = (from r in dc.RIDDATAs
                            select new CampaignView1
                            {
                                Id = r.PK_Rid,
                                ReferenceNumber = r.ReferenceNumber,
                                // pwd = r.Pwd,
                                IsActive = r.IsActive
                            }).ToList();
                    return Json(objc, JsonRequestBehavior.AllowGet);

                }
                else if (id != null && Session["id"] != "")
                {
                    obj = (from r in dc.RIDDATAs
                           where r.PK_Rid == id1
                           select new CampaignView1
                           {
                               Id = r.PK_Rid,
                               ReferenceNumber = r.ReferenceNumber,
                               //pwd = r.Pwd,
                               IsActive = r.IsActive
                           }).SingleOrDefault();
                    return Json(obj, JsonRequestBehavior.AllowGet);

                }


                return Json(objc, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(objc, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Search(string referencenumber, bool? isactive)
        {
            List<CampaignView1> obj_search = new List<CampaignView1>();
            string isactivestr = Convert.ToString(isactive);

            try
            {
                if (Session["id"] != null)
                {
                    if (referencenumber != null && isactivestr == "" && Session["id"] != null)
                    {
                        obj_search = (from c in dc.RIDDATAs
                                      join c1 in dc.Clients on c.FK_ClientId equals c1.PK_ClientID
                                      where c.ReferenceNumber.Contains(referencenumber.ToString()) && c.CampaignName.ToString() != null && c.CampaignName.ToString() != ""
                                      select new CampaignView1()
                                      {
                                          Id = c.PK_Rid,
                                          ReferenceNumber = c.ReferenceNumber,
                                          CampaignName = c.CampaignName,
                                          HasPassword = (c.Pwd != null && c.Pwd != string.Empty) ? true : false,
                                          //pwd = r.Pwd,
                                          IsActive = c.IsActive,
                                          CreatedDateStr = c.CreatedDate,
                                          CreatedUserId = c1.PK_ClientID,
                                          CreatedUserEmail = c1.Email,
                                          CreatedUserName = c1.UserName,
                                          CreatedUserActiveState = c1.IsActive
                                      }).ToList();
                        obj_search = (from x in obj_search
                                      select new CampaignView1()
                                      {
                                          Id = x.Id,
                                          ReferenceNumber = x.ReferenceNumber,
                                          CampaignName = x.CampaignName,
                                          HasPassword = x.HasPassword,
                                          //pwd = r.Pwd,
                                          IsActive = x.IsActive,
                                          //CreatedDate = x.CreatedDate.ToString(),
                                          CreatedDate = x.CreatedDateStr.Value.ToString("yyyy-MM-ddThh:mm:ss"),
                                          CreatedUserId = x.CreatedUserId,
                                          CreatedUserEmail = x.CreatedUserEmail,
                                          CreatedUserName = x.CreatedUserName,
                                          CreatedUserActiveState = x.CreatedUserActiveState
                                      }).ToList();
                    }

                    else if (isactivestr != "" && referencenumber == null && Session["id"] != null)
                    {
                        obj_search = (from c in dc.RIDDATAs
                                      join c1 in dc.Clients on c.FK_ClientId equals c1.PK_ClientID
                                      where c.IsActive == isactive && c.CampaignName.ToString() != null && c.CampaignName.ToString() != ""
                                      select new CampaignView1()
                                      {
                                          Id = c.PK_Rid,
                                          ReferenceNumber = c.ReferenceNumber,
                                          CampaignName = c.CampaignName,
                                          HasPassword = (c.Pwd != null && c.Pwd != string.Empty) ? true : false,
                                          //pwd = r.Pwd,
                                          IsActive = c.IsActive,
                                          CreatedDateStr = c.CreatedDate,
                                          CreatedUserId = c1.PK_ClientID,
                                          CreatedUserEmail = c1.Email,
                                          CreatedUserName = c1.UserName,
                                          CreatedUserActiveState = c1.IsActive
                                      }).ToList();
                        obj_search = (from x in obj_search
                                      select new CampaignView1()
                                      {
                                          Id = x.Id,
                                          ReferenceNumber = x.ReferenceNumber,
                                          CampaignName = x.CampaignName,
                                          HasPassword = x.HasPassword,
                                          //pwd = r.Pwd,
                                          IsActive = x.IsActive,
                                          //CreatedDate = x.CreatedDate.ToString(),
                                          CreatedDate = x.CreatedDateStr.Value.ToString("yyyy-MM-ddThh:mm:ss"),
                                          CreatedUserId = x.CreatedUserId,
                                          CreatedUserEmail = x.CreatedUserEmail,
                                          CreatedUserName = x.CreatedUserName,
                                          CreatedUserActiveState = x.CreatedUserActiveState
                                      }).ToList();
                    }
                    else if (isactivestr == "" && referencenumber == null && Session["id"] != null)
                    {
                        obj_search = (from c in dc.RIDDATAs
                                      join c1 in dc.Clients on c.FK_ClientId equals c1.PK_ClientID
                                      where c.CampaignName.ToString() != null && c.CampaignName.ToString() != ""
                                      select new CampaignView1()
                                      {
                                          Id = c.PK_Rid,
                                          ReferenceNumber = c.ReferenceNumber,
                                          CampaignName = c.CampaignName,
                                          HasPassword = (c.Pwd != null && c.Pwd != string.Empty) ? true : false,
                                          //pwd = r.Pwd,
                                          IsActive = c.IsActive,
                                          CreatedDateStr = c.CreatedDate,
                                          //CreatedDate = c.CreatedDate.Value.ToString("yyyy-MM-ddThh:mm:ss"),
                                          CreatedUserId = c1.PK_ClientID,
                                          CreatedUserEmail = c1.Email,
                                          CreatedUserName = c1.UserName,
                                          CreatedUserActiveState = c1.IsActive
                                      }).ToList();
                        obj_search = (from x in obj_search
                                      select new CampaignView1()
                                   {
                                       Id = x.Id,
                                       ReferenceNumber = x.ReferenceNumber,
                                       CampaignName = x.CampaignName,
                                       HasPassword = x.HasPassword,
                                       //pwd = r.Pwd,
                                       IsActive = x.IsActive,
                                       //CreatedDate = x.CreatedDate.ToString(),
                                       CreatedDate = x.CreatedDateStr.Value.ToString("yyyy-MM-ddThh:mm:ss"),
                                       CreatedUserId = x.CreatedUserId,
                                       CreatedUserEmail = x.CreatedUserEmail,
                                       CreatedUserName = x.CreatedUserName,
                                       CreatedUserActiveState = x.CreatedUserActiveState
                                   }).OrderByDescending(c => c.CreatedDate).ToList();

                    }
                    return Json(obj_search, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Error obj_err = new Error();
                    Errormessage errmesobj = new Errormessage();
                    errmesobj.message = "Session Expired.";
                    obj_err.error = errmesobj;
                    return Json(obj_err, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(obj_search, JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult AddCampaign([FromBody]JToken jObject)
        [System.Web.Mvc.HttpPost]
        public JsonResult AddCampaign(string CampaignName, string CreatedUserId, string Pwd, bool IsActive)
        {
            RIDDATA obj = new RIDDATA();
            CampaignView1 obj_search = new CampaignView1();

            try
            {
                Random randNum = new Random();
                int r = randNum.Next(00000, 99999);
                string ReferenceNumber = r.ToString("D5");
                int cid;
                cid = Helper.CurrentUserId;

                if (CreatedUserId != null&&CreatedUserId!="")
                    cid = Convert.ToInt32(CreatedUserId);
                
                //string fields = "id,ReferenceNumber,isactive";

                //string ReferenceNumber = (string)jObject["ReferenceNumber"];
                //string Pwd = (string)jObject["Pwd"];
                //bool IsActive = (bool)jObject["IsActive"];
                //int id = (int)Session["id"];
                //int id = 1;
                // RIDDATA objc = dc.RIDDATAs.Where(x => x.ReferenceNumber== ReferenceNumber).SingleOrDefault();
                //int FK_ClientId = (int)jObject["ClientId"];
                //bool isClientExists = new OperationsBO().CheckClientId(FK_ClientId);
                RIDDATA objr = dc.RIDDATAs.Where(r1 => r1.FK_ClientId == cid && r1.CampaignName == CampaignName).SingleOrDefault();
                if (Session["id"] != null && objr == null && CampaignName != "" && CampaignName != null)
                {
                    //if (Session["id"] != null && CampaignName != "" && CampaignName != null)
                    //{

                        
                            //add campaign details
                            obj.CampaignName = CampaignName;
                            obj.ReferenceNumber = ReferenceNumber;
                            obj.Pwd = Pwd;
                            obj.IsActive = IsActive;
                            obj.CreatedDate = DateTime.UtcNow;
                            obj.CreatedBy = Helper.CurrentUserId;
                            obj.FK_ClientId = cid;
                            dc.RIDDATAs.Add(obj);
                            dc.SaveChanges();
                        
                        obj_search = (from c in dc.RIDDATAs
                                      join c1 in dc.Clients on c.FK_ClientId equals c1.PK_ClientID
                                      where c.ReferenceNumber == ReferenceNumber
                                      select new CampaignView1()
                                      {
                                          Id = c.PK_Rid,
                                          ReferenceNumber = c.ReferenceNumber,
                                          CampaignName = c.CampaignName,
                                          HasPassword = (c.Pwd != null && c.Pwd != string.Empty) ? true : false,
                                          //pwd = r.Pwd,
                                          IsActive = c.IsActive,
                                          CreatedDateStr = c.CreatedDate,
                                          CreatedUserId = c1.PK_ClientID,
                                          CreatedUserEmail = c1.Email,
                                          CreatedUserName = c1.UserName,
                                          CreatedUserActiveState = c1.IsActive
                                      }).SingleOrDefault();
                        obj_search.CreatedDate = obj_search.CreatedDateStr.Value.ToString("yyyy-MM-ddThh:mm:ss");
                        //obj_search = (from x in obj_search
                        //              select new CampaignView1()
                        //              {
                        //                  Id = x.Id,
                        //                  ReferenceNumber = x.ReferenceNumber,
                        //                  CampaignName = x.CampaignName,
                        //                  HasPassword = x.HasPassword,
                        //                  //pwd = r.Pwd,
                        //                  IsActive = x.IsActive,
                        //                  //CreatedDate = x.CreatedDate.ToString(),
                        //                  CreatedDate = x.CreatedDateStr.Value.ToString("yyyy-MM-ddThh:mm:ss"),
                        //                  CreatedUserId = x.CreatedUserId,
                        //                  CreatedUserEmail = x.CreatedUserEmail,
                        //                  CreatedUserName = x.CreatedUserName,
                        //                  CreatedUserActiveState = x.CreatedUserActiveState
                        //              }).SingleOrDefault();
                        // new OperationsBO().InsertUIDRIDData(ReferenceNumber);
                       // return Json(obj_search, JsonRequestBehavior.AllowGet);
                    //}
                    return Json(obj_search, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Error obj_err = new Error();
                if(objr!=null)
                {
                    Errormessage errmesobj = new Errormessage();
                    errmesobj.message = "CampaignName already Exists for this Client.";
                    obj_err.error = errmesobj;
                  }
                else if (Session["id"] == null)
                    {
                        Errormessage errmesobj = new Errormessage();
                        errmesobj.message = "Session Expired.";
                        obj_err.error = errmesobj;
                        //return Json(obj_err, JsonRequestBehavior.AllowGet);
                    }
                    else if (CampaignName == "" || CampaignName == null)
                    {
                        Errormessage errmesobj = new Errormessage();
                        errmesobj.message = "CampaignName is should not be empty.";
                        obj_err.error = errmesobj;
                       // return Json(obj_err, JsonRequestBehavior.AllowGet);
                    }
                    return Json(obj_err, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult UpdateCampaign([FromBody]JToken jObject)
        [System.Web.Mvc.HttpPost]
        public JsonResult UpdateCampaign(string Id, string CampaignName, string ReferenceNumber, string Pwd, bool IsActive)
        {
            RIDDATA obj = new RIDDATA();
            RIDDATA obj1 = new RIDDATA();
            CampaignView1 objc = new CampaignView1();
            try
            {
                //string fields = "id,ReferenceNumber,isactive";
                //string parameters = new StreamReader(parameter).ReadToEnd(); //email1;
                //JObject jObject = JObject.Parse(parameter);
                //int id = (int)jObject["id"];
                //string ReferenceNumber = (string)jObject["ReferenceNumber"];
                //string Pwd = (string)jObject["Pwd"];
                //bool IsActive = (bool)jObject["IsActive"];
                if (Session["id"] != null)
                {
                    obj = dc.RIDDATAs.Where(r => r.ReferenceNumber == ReferenceNumber).SingleOrDefault();
                    //obj = (from rid in dc.RIDDATAs
                    //       where rid.ReferenceNumber == ReferenceNumber
                    //       select rid).SingleOrDefault();
                    // bool isReferenceNumberExists = new OperationsBO().CheckReferenceNumber(ReferenceNumber);
                    if (obj != null)
                        new OperationsBO().UpdateCampaign(ReferenceNumber, CampaignName, Pwd, IsActive);
                    else
                        obj = obj1;
                    objc = (from c in dc.RIDDATAs
                            join c1 in dc.Clients on c.FK_ClientId equals c1.PK_ClientID
                            where c.ReferenceNumber == ReferenceNumber
                            select new CampaignView1()
                            {
                                Id = c.PK_Rid,
                                ReferenceNumber = c.ReferenceNumber,
                                CampaignName = c.CampaignName,
                                HasPassword = (c.Pwd != null && c.Pwd != string.Empty) ? true : false,
                                //pwd = r.Pwd,
                                IsActive = c.IsActive,
                                CreatedDateStr = c.CreatedDate,
                                CreatedUserId = c1.PK_ClientID,
                                CreatedUserEmail = c1.Email,
                                CreatedUserName = c1.UserName,
                                CreatedUserActiveState = c1.IsActive
                            }).SingleOrDefault();
                    objc.CreatedDate = objc.CreatedDateStr.Value.ToString("yyyy-MM-ddThh:mm:ss");
                    return Json(objc, JsonRequestBehavior.AllowGet);
                    //     return Json(
                    //new CampaignView1()
                    //{

                    //ReferenceNumber=obj.ReferenceNumber,
                    //IsActive=obj.IsActive}
                    //, JsonRequestBehavior.AllowGet
                    //);
                }
                else
                {
                    Error obj_err = new Error();
                    Errormessage errmesobj = new Errormessage();
                    errmesobj.message = "Session Expired.";
                    obj_err.error = errmesobj;
                    Response.StatusCode = 401;
                    return Json(obj_err, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }

        // public JsonResult DeleteCampaign([FromBody]JToken jObject)
        [System.Web.Mvc.HttpPost]
        public JsonResult DeleteCampaign(string ReferenceNumber)
        {
            RIDDATA obj = new RIDDATA();
            RIDDATA obj1 = new RIDDATA();
            try
            {
                //string fields = "id,ReferenceNumber,isactive";
                //string parameters = new StreamReader(parameter).ReadToEnd(); //email1;
                //JObject jObject = JObject.Parse(parameter);
                //int id = (int)jObject["id"];
                //string ReferenceNumber = (string)jObject["ReferenceNumber"];
                //string Pwd = (string)jObject["Pwd"];
                //bool IsActive = (bool)jObject["IsActive"];
                //obj = dc.RIDDATAs.Where(r => r.ReferenceNumber == ReferenceNumber).Select(r=>r).SingleOrDefault();
                if (Session["id"] != null)
                {
                    obj = dc.RIDDATAs.Where(r => r.ReferenceNumber == ReferenceNumber).SingleOrDefault();

                    //bool isReferenceNumberExists = new OperationsBO().CheckReferenceNumber(ReferenceNumber);
                    if (obj != null && obj.IsActive == true)
                    {
                        obj.IsActive = false;
                        obj.UpdatedDate = DateTime.UtcNow;
                        dc.SaveChanges();

                    }
                    else
                    {
                        obj = obj1;
                    }
                    return Json(
             new
             {
                 referencenumber = obj.ReferenceNumber,
                 IsActive = obj.IsActive
             }
             , JsonRequestBehavior.AllowGet
             );
                    //return Json(obj, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    Error obj_err = new Error();
                    Errormessage errmesobj = new Errormessage();
                    errmesobj.message = "Session Expired.";
                    obj_err.error = errmesobj;
                    return Json(obj_err, JsonRequestBehavior.AllowGet);

                }
            }

            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return Json(obj, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetBatchStatus(int BatchID)
        {
            BatchUploadData objb = dc.BatchUploadDatas.Where(x => x.PK_Batchid == BatchID).SingleOrDefault();
            BatchStatus objs = new BatchStatus();
            if(objb!=null)
            {
                //if (objb.Status == "Not Started" || objb.Status=="In Progress"|| objb.Status == "Insertion Completed" || objb.Status=="Completed")
                //{
                    objs.Status = objb.Status;
                    objs.BatchID = objb.PK_Batchid;
                //}
                
            }
            return Json(objs,JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBatchIDs(string ReferenceNumber)
        {
            List<BatchIDList> objbs = new List<BatchIDList>();
            List<BatchUploadData> objb = new List<BatchUploadData>();

            if(Session["userdata"]!=null)
            {
                int currentuserid = Helper.CurrentUserId;
                string role = Helper.CurrentUserRole;
                if(role.ToLower()=="admin")
                {
                    objb = dc.BatchUploadDatas.Where(x => x.ReferenceNumber == ReferenceNumber).ToList();

                }
                else 
                objb = dc.BatchUploadDatas.Where(x => x.FK_ClientID == currentuserid && x.ReferenceNumber == ReferenceNumber).ToList();
                if(objb.Count!=0)
                {
                    objbs = (from b in objb
                             select new BatchIDList()
                             {
                                 CreatedDate = b.CreatedDate.Value.ToString("yyyy-MM-ddThh:mm:ss"),
                                 BatchID = b.PK_Batchid,
                                 BatchName=b.BatchName,
                                 Status=b.Status
                             }).ToList();
                }
                return Json(objbs, JsonRequestBehavior.AllowGet);
            }
            return Json(objbs, JsonRequestBehavior.AllowGet);
        }
        public void GetBatchDownloadedFile(int BatchID)
        {
            
             BatchUploadData objb = dc.BatchUploadDatas.Where(x => x.PK_Batchid == BatchID).SingleOrDefault();
            if (objb != null)
            {
                string host = ConfigurationManager.AppSettings["ShortenurlHost"].ToString();
                List<BatchDownload> objd = (from u in dc.UIDDATAs
                                            where u.FK_Batchid == objb.PK_Batchid
                                            select new BatchDownload()
                                            {
                                                Mobilenumber = u.MobileNumber,
                                                ShortUrl=host+u.UniqueNumber
                                                //ShortUrl="https://g0.pe/" + u.UniqueNumber
                                            }).ToList();
                var grid = new System.Web.UI.WebControls.GridView();
                string filename = objb.BatchName;
                grid.DataSource = objd;
                grid.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename="+filename +".xls");
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grid.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();
            }

        }
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }

        [System.Web.Http.HttpPost]
         public JsonResult UploadData(string[] MobileNumbers, string LongURL, string ReferenceNumber, string type)
       {
               //<add key="aspnet:MaxJsonDeserializerMembers" value="15000000" />
            try
            {
                int clientid = 0; int rid = 0;
                exportDataModel obje = new exportDataModel();
                // MobileNumbers = "{\"MobileNumbers\":[\"8331877564\",\"9848745783\"]}";
                //MobileNumbers = "8331877564,9848745783";
                //ReferenceNumber = "50793";
                //LongURL = "google.com";
                //type = "advanced";
                
                List<string> MobileNumbersList = new List<string>();
                List<string> MobileNumbersFiltered_List = new List<string>();

                List<string> shorturls = new List<string>();
                List<string> outputdat = new List<string>();
                List<int> pkuids = new List<int>();
                string Hashid;
                //MobileNumbersList MobileNumbersList1 = ser.Deserialize<MobileNumbersList>(MobileNumbers);
                //MobileNumbersList = MobileNumbersList1.MobileNumbers;
                //MobileNumbersList = MobileNumbers.Split(',').ToList();

                string formated_mobilenumbers = String.Join(",", MobileNumbers);

                //clientid = 2;
                //rid = 41;

                RIDDATA objrid = (from registree in dc.RIDDATAs
                                  where registree.ReferenceNumber.Trim() == ReferenceNumber.Trim()
                                  select registree).SingleOrDefault();
                if (type.ToLower() == "simple" && objrid != null)
                {
                    string mobilenumber = MobileNumbers[0];
                    UIDDATA objc = new UIDDATA();
                    UIDDATA objc1 = dc.UIDDATAs.Where(u => u.MobileNumber == mobilenumber && u.ReferenceNumber == ReferenceNumber && u.Longurl == LongURL).SingleOrDefault();
                    if (objc1 == null)
                    {
                        objc.MobileNumber = mobilenumber;
                        objc.ReferenceNumber = ReferenceNumber;
                        objc.Longurl = LongURL;
                        objc.FK_ClientID = objrid.FK_ClientId;
                        objc.FK_RID = objrid.PK_Rid;
                        objc.CreatedDate = DateTime.UtcNow;
                        objc.CreatedBy = Helper.CurrentUserId;
                        dc.UIDDATAs.Add(objc);
                        dc.SaveChanges();
                        UIDDATA objuid = dc.UIDDATAs.Where(u => u.MobileNumber == mobilenumber && u.ReferenceNumber == ReferenceNumber && u.Longurl == LongURL).SingleOrDefault();
                        Hashid = Helper.GetHashID(objuid.PK_Uid);
                        new OperationsBO().UpdateHashid(objuid.PK_Uid, Hashid);
                        obje.MobileNumber = mobilenumber;
                        //obje.ShortenUrl = "https://g0.pe/" + Hashid;
                        obje.ShortenUrl = ConfigurationManager.AppSettings["ShortenurlHost"].ToString() + Hashid;
                        obje.CreatedDate = objuid.CreatedDate;
                        obje.Status = "Successfully Uploaded.";
                        //return Json(obje, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        obje.MobileNumber = mobilenumber;
                        obje.ShortenUrl = "cannt be generated.";
                        obje.Status = "MobileNumber and LongUrl already added for this campaign.";
                        //return Json(obje, JsonRequestBehavior.AllowGet);

                    }

                }
                else if (type.ToLower() == "advanced" && objrid != null)
                {
                    string batchname = objrid.CampaignName + "_" + DateTime.UtcNow;
                    
                        BatchUploadData objb = new BatchUploadData();
                        objb.ReferenceNumber = ReferenceNumber;
                        objb.MobileNumber = formated_mobilenumbers;
                        objb.Longurl = LongURL;
                        objb.FK_ClientID = objrid.FK_ClientId;
                        objb.FK_RID = objrid.PK_Rid;
                        objb.CreatedDate = DateTime.UtcNow;
                        objb.CreatedBy = Helper.CurrentUserId.ToString();
                        objb.Status = "Not Started";
                        objb.BatchName = batchname;
                        dc.BatchUploadDatas.Add(objb);
                        dc.SaveChanges();
                    
                   
                    BatchUploadData objo = dc.BatchUploadDatas.Where(x => x.BatchName == batchname).SingleOrDefault();
                    if (objo != null)
                    {
                        obje.Status = objo.BatchName + " Created.Revert Back to you once upload has done.";
                        obje.BatchID = objo.PK_Batchid;
                        obje.CreatedDate = objo.CreatedDate;
                    }
                    // return Json(obje, JsonRequestBehavior.AllowGet);
                    //clientid = objrid.FK_ClientId;
                    //rid = objrid.PK_Rid;
                    //List<string> mobilenumberdata = dc.UIDDATAs.AsNoTracking().Where(x => MobileNumbersList.Contains(x.MobileNumber) && x.ReferenceNumber == ReferenceNumber && x.FK_RID == rid && x.FK_ClientID == clientid && x.Longurl == LongURL).Select(r => r.MobileNumber).ToList();
                    //if (mobilenumberdata.Count != 0)
                    //{
                    //    MobileNumbersFiltered_List = MobileNumbersList.Except(mobilenumberdata).ToList();
                    //}
                    //else
                    //{ MobileNumbersFiltered_List = MobileNumbersList; }
                    //if (MobileNumbersFiltered_List.Count > 0)
                    //{
                    //    foreach (string m in MobileNumbersFiltered_List)
                    //    {
                    //        new DataInsertionBO().InsertUIDdata(rid, clientid, ReferenceNumber, LongURL, m);
                    //    }

                    //    pkuids = dc.UIDDATAs.AsNoTracking().Where(x => MobileNumbersFiltered_List.Contains(x.MobileNumber) && x.ReferenceNumber == ReferenceNumber && x.FK_RID == rid && x.FK_ClientID == clientid && x.Longurl == LongURL).Select(r => r.PK_Uid).ToList();
                    //    foreach (int uid in pkuids)
                    //    {
                    //        Hashid = "";
                    //        Hashid = Helper.GetHashID(uid);
                    //        new OperationsBO().UpdateHashid(uid, Hashid);
                    //        // shorturls.Add("https://g0.pe/" + Hashid);
                    //    }
                    //}
                    //List<exportDataModel> exportdata = dc.UIDDATAs.AsNoTracking().Where(x => MobileNumbersList.Contains(x.MobileNumber) && x.ReferenceNumber == ReferenceNumber && x.FK_RID == rid && x.FK_ClientID == clientid && x.Longurl == LongURL).Select(r => new exportDataModel() { MobileNumber = r.MobileNumber, ShortenUrl = r.UniqueNumber }).ToList();
                    //exportdata = exportdata.Select(x => { x.ShortenUrl = "https://g0.pe/" + x.ShortenUrl; return x; }).ToList();
                    ////DataTable dt = new DataTable();
                    ////dt.Columns.Add("Mobilenumber");
                    ////dt.Columns.Add("ShortUrl");
                    ////foreach (exportDataModel e in exportdata)
                    ////{
                    ////    dt.Rows.Add(e.MobileNumber, "https://g0.pe/" + e.ShortenUrl);
                    ////}

                    //var grid = new System.Web.UI.WebControls.GridView();

                    //grid.DataSource = exportdata;
                    //grid.DataBind();
                    //Response.ClearContent();
                    //Response.AddHeader("content-disposition", "attachment; filename=ShortURLSList.xls");
                    //Response.ContentType = "application/excel";
                    //StringWriter sw = new StringWriter();
                    //HtmlTextWriter htw = new HtmlTextWriter(sw);
                    //grid.RenderControl(htw);
                    //Response.Write(sw.ToString());
                    //Response.End();

                }
                return Json(obje, JsonRequestBehavior.AllowGet);
            }
               
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.InnerException.ToString());
                return null;
            }
        }


        public void UploadData1(string[] MobileNumbers,string LongURL,string ReferenceNumber,string type)
         {
            int clientid = 0; int rid = 0;
            var mobilenumbers = "{\"MobileNumbers\":[\"8331877564\",\"9848745783\"]}";
            ReferenceNumber = "50793";
            LongURL = "google.com";
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<string> MobileNumbersList = new List<string>();
            List<string> MobileNumbersFiltered_List = new List<string>();

            List<string> shorturls = new List<string>();
            List<string> outputdat = new List<string>();
            List<int> pkuids = new List<int>();
            string Hashid;
            MobileNumbersList MobileNumbersList1 = ser.Deserialize<MobileNumbersList>(mobilenumbers);
            MobileNumbersList = MobileNumbersList1.MobileNumbers;
            //clientid = 2;
            //rid = 41;
           
            RIDDATA objrid = (from registree in dc.RIDDATAs
                              where registree.ReferenceNumber.Trim() == ReferenceNumber.Trim()
                              select registree).SingleOrDefault();
            if (objrid != null)
            {
                clientid = objrid.FK_ClientId;
                rid = objrid.PK_Rid;
                List<string> mobilenumberdata = dc.UIDDATAs.AsNoTracking().Where(x => MobileNumbersList.Contains(x.MobileNumber) && x.ReferenceNumber == ReferenceNumber && x.FK_RID == rid && x.FK_ClientID == clientid && x.Longurl == LongURL).Select(r=>r.MobileNumber).ToList();
                if (mobilenumberdata.Count != 0)
                {
                    MobileNumbersFiltered_List = MobileNumbersList.Except(mobilenumberdata).ToList();
                }
                else
                { MobileNumbersFiltered_List = MobileNumbersList; }
                if (MobileNumbersFiltered_List.Count > 0)
                {
                    foreach (string m in MobileNumbersFiltered_List)
                    {
                        new DataInsertionBO().InsertUIDdata(rid, clientid, ReferenceNumber, LongURL, m);
                    }

                    pkuids = dc.UIDDATAs.AsNoTracking().Where(x => MobileNumbersFiltered_List.Contains(x.MobileNumber) && x.ReferenceNumber == ReferenceNumber && x.FK_RID == rid && x.FK_ClientID == clientid && x.Longurl == LongURL).Select(r => r.PK_Uid).ToList();
                    foreach (int uid in pkuids)
                    {
                        Hashid = "";
                        Hashid = Helper.GetHashID(uid);
                        new OperationsBO().UpdateHashid(uid, Hashid);
                        // shorturls.Add("https://g0.pe/" + Hashid);
                    }
                }
                List<exportDataModel> exportdata = dc.UIDDATAs.AsNoTracking().Where(x => MobileNumbersList.Contains(x.MobileNumber) && x.ReferenceNumber == ReferenceNumber && x.FK_RID == rid && x.FK_ClientID == clientid && x.Longurl == LongURL).Select(r=>new exportDataModel(){MobileNumber=r.MobileNumber,ShortenUrl=r.UniqueNumber}).ToList();
                exportdata = exportdata.Select(x => { x.ShortenUrl = "https://g0.pe/" + x.ShortenUrl; return x; }).ToList();
                //DataTable dt = new DataTable();
                //dt.Columns.Add("Mobilenumber");
                //dt.Columns.Add("ShortUrl");
                //foreach (exportDataModel e in exportdata)
                //{
                //    dt.Rows.Add(e.MobileNumber, "https://g0.pe/" + e.ShortenUrl);
                //}

                var grid = new System.Web.UI.WebControls.GridView();

                grid.DataSource = exportdata;
                grid.DataBind();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=ShortURLSList.xls");
                Response.ContentType = "application/excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);
                grid.RenderControl(htw);
                Response.Write(sw.ToString());
                Response.End();

            }

        }

    }
}