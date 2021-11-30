using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlertBL : IAlertBL
    {
        public IAlertDL alertDL;
        public AlertBL(IAlertDL alertDL)
        {
            this.alertDL = alertDL;
        }

        public void deleteAlert(int id)
        {
            alertDL.deleteAlert(id);
        }

        public async Task<List<Alert>> getAlertsForCalender(DateTime start, DateTime end)
        {
            return await alertDL.getAlertsForCalender(start, end);
        }


        public async Task<List<Alert>> getRelevantAlerts(DateTime date)
        {
            return await alertDL.getRelevantAlerts(date);
        }
        public async Task<int> insertAlert(Alert newAlert)
        {
            return await alertDL.insertAlert(newAlert);
        }

        public void updateAlert(Alert alertToUpdate)
        {
            alertDL.updateAlert(alertToUpdate);
        }
    }
}
