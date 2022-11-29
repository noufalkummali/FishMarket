using FishMarketing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarketing.Data
{
   public interface IBoxMarks
    {
        List<BoxMark> GetBoxMarksList();
        BoxMark GetBoxMark(int id);
        string AddBoxMark(BoxMark boxMark);
        string UpdateBoxMark(BoxMark boxMark);
        string DeleteBoxMark(BoxMark boxMark);

    }
}
