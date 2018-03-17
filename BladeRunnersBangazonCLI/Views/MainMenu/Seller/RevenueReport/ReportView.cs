using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BladeRunnersBangazonCLI.Views
{
    class ReportView : View
    {
        internal View AddReportTitleLine(string reportName, string activeUserName)
        {
            var title = $"{Environment.NewLine}{reportName} for {activeUserName}{Environment.NewLine}";
            _menuItems.Add(title);
            return this;
        }

        internal View AddReportSection(string sectionText)
        {
            var title = $"{Environment.NewLine}{sectionText}{Environment.NewLine}--------------------------------------{Environment.NewLine}";
            _menuItems.Add(title);
            return this;
        }

        internal View AddReportLineItem(string rowName, int count, double total)
        {
            var lineItem = $"{ Environment.NewLine }{rowName}                {count}               {total}";
            _menuItems.Add(lineItem);
            return this;
        }

        internal View AddColumnHeaders(string row1, string row2, string row3)
        {
            var column = $"{row1}       {row2}          {row3}";
            _menuItems.Add(column);
            return this;
        }
    }
}
