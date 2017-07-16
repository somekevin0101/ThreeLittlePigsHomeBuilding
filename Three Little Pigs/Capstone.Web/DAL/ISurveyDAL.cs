using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeLittlePigs.Web.Models;

namespace ThreeLittlePigs.Web.DAL
{
    public interface ISurveyDAL
    {
        List<Survey> AllSurveys();
        int GetVotes(string houseCode);
        void SaveSurvey(Survey s);
    }
}
