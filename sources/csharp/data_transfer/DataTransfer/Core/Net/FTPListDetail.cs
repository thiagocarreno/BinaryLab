using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DataTransfer.Core.Net
{
    public class FTPListDetail
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public int Size { get; set; }
        public string Filecode { get; set; }
        public string Permission { get; set; }
        public string Owner { get; set; }
        public string Group { get; set; }
        
        internal string Dir { get; set; }
        internal string Month { get; set; }
        internal string Day { get; set; }
        internal string YearTime { get; set; }

        public bool IsDirectory
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.Dir) && 
                    string.Equals(
                        this.Dir,
                        "D",
                        StringComparison.OrdinalIgnoreCase
                    );
            }
        }

        public DateTime Date
        {
            get
            {
                var month = DateTime.ParseExact(
                    this.Month,
                    "MMM",
                    CultureInfo.CurrentCulture
                ).Month;
                
                if (!YearTime.Contains(":"))
                {
                    int year = 0;
                    int.TryParse(this.YearTime, out year);

                    var day = 0;
                    int.TryParse(this.Day, out day);

                    return new DateTime(
                        year, 
                        month,
                        day
                    );
                }
                else
                {
                    int day = 0;
                    var dateTime = YearTime
                        .Split(
                            new string[] 
                            { 
                                ":"
                            }, 
                            StringSplitOptions.RemoveEmptyEntries
                    );
                    
                    if (dateTime.Count() == 2)
                    {
                        int hour = 0;
                        int.TryParse(dateTime[0], out hour);

                        int minute = 0;
                        int.TryParse(dateTime[1], out minute);

                        int.TryParse(this.Day, out day);

                        return new DateTime(
                            DateTime.Now.Year,
                            month,
                            day,
                            hour,
                            minute,
                            0
                        );
                    }

                    day = 0;
                    int.TryParse(this.Day, out day);

                    return new DateTime(
                        DateTime.Now.Year,
                        month,
                        day
                    );
                }
            }
        }

        public override string ToString()
        {
            return string.Format(
                "{0} {1} {2} {3} {4} {5} {6} {7}",
                this.Dir,
                this.Permission,
                this.Filecode,
                this.Owner,
                this.Group,
                this.Size,
                this.Date.ToShortDateString(),
                this.Name
            );
        }
    }
}