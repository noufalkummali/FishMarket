using FishMarketing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarketing.Data
{
    public class BoxMarkData : IBoxMarks
    {
        private readonly FishMarketContext _db;
        public BoxMarkData(FishMarketContext db)//Dependancy Injuction
        {
            _db = db;
        }
        public string AddBoxMark(BoxMark boxMark)
        {
            try
            {
                _db.BoxMarks.Add(boxMark);
                _db.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public string DeleteBoxMark(BoxMark boxMark)
        {
            
            try
            {
                _db.BoxMarks.Remove(boxMark);                
                _db.SaveChanges();
                 return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public BoxMark GetBoxMark(int id)
        {
            BoxMark boxMark = new BoxMark();
            try
            {
                boxMark=_db.BoxMarks.Find(id);                
                return boxMark;
            }
            catch (Exception ex)
            {
                //boxMark.Remarks = ex.Message.ToString();
                return boxMark;
            }
        }

        public List<BoxMark> GetBoxMarksList()
        {
            List<BoxMark> boxMark = new List<BoxMark>();
            try
            {                
                boxMark = _db.BoxMarks.ToList();
                return boxMark;
            }
            catch (Exception ex)
            {
                //boxMark[0].Remarks = ex.Message.ToString();
                return boxMark;
            }
        }

        public string UpdateBoxMark(BoxMark boxMark)
        {
            try
            {
                _db.BoxMarks.Update(boxMark);
                _db.SaveChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
