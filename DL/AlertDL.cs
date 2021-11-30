using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class AlertDL:IAlertDL
    {
        MyTravelAgentContext myContext;
        public AlertDL(MyTravelAgentContext myContext)
        {
            this.myContext = myContext;
        }

        public async Task<List<Alert>> getAlertsForCalender(DateTime start, DateTime end)
        {
            return await myContext.Alerts.Where(alert=> alert.Date >=start && alert.Date <=end).ToListAsync();
        }

        public async Task<List<Alert>> getRelevantAlerts(DateTime date)
        { 
            return await myContext.Alerts.Where(a => a.Date< date).ToListAsync();
        }
        public async Task<int> insertAlert(Alert newAlert)
        {
            await myContext.Alerts.AddAsync(newAlert);
            myContext.SaveChanges();
            return newAlert.Id;
        }

        public void updateAlert(Alert alertToUpdate)
        {

            //להשלים!!!!!
        }
        public void deleteAlert(int id)
        {
          Alert alertToDelete = myContext.Alerts.Find(id);
            myContext.Alerts.Remove(alertToDelete);
            myContext.SaveChanges();
        }
    }
}
