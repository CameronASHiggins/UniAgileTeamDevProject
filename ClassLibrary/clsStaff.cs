using System;

namespace ClassLibrary
{
    public class clsStaff
    {
        private Int32 mStaffId;
        private DateTime mStartDate;
        private string mFirstName;
        private string mLastName;
        private string mEmailAddress;
        private string mHomeAddress;
        private bool mIsWorking;

        public bool IsWorking {
            get
            {
                return mIsWorking;
            }
            set
            {
                mIsWorking = value;
            }
        }
        public DateTime StartDate {
            get
            {
                return mStartDate;
            }
            set
            {
                mStartDate = value;
            }
        }
        public int StaffId {
            get
            {
                return mStaffId;
            }
            set
            {
                mStaffId = value;
            }
        }
        public string FirstName {
            get
            {
                return mFirstName;
            }
            set
            {
                mFirstName = value;
            }
        }
        public string LastName {
            get
            {
                return mLastName;
            }
            set
            {
                mLastName = value;
            }
        }
        public string EmailAddress {
            get
            {
                return mEmailAddress;
            }
            set
            {
                mEmailAddress = value;
            }
        }
        public string HomeAddress {
            get
            {
                return mHomeAddress;
            }
            set
            {
                mHomeAddress = value;
            }
        }

        public bool Find(int staffId)
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@StaffId", staffId);
            DB.Execute("sproc_tblStaff_FilterByStaffId");
            if (DB.Count == 1)
            {
                mStaffId = Convert.ToInt32(DB.DataTable.Rows[0]["StaffId"]);
                mFirstName = Convert.ToString(DB.DataTable.Rows[0]["FirstName"]);
                mLastName = Convert.ToString(DB.DataTable.Rows[0]["LastName"]);
                mEmailAddress = Convert.ToString(DB.DataTable.Rows[0]["EmailAddress"]);
                mHomeAddress = Convert.ToString(DB.DataTable.Rows[0]["HomeAddress"]);
                mStartDate = Convert.ToDateTime(DB.DataTable.Rows[0]["StartDate"]);
                mIsWorking = Convert.ToBoolean(DB.DataTable.Rows[0]["IsWorking"]);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public string Valid(string firstName, string lastName, string emailAddress, string homeAddress, string startDate)
        {
            String Error = "";

            DateTime TempDate;
            // First name validation
            if (firstName.Length == 0)
            {
                Error = Error + "The first name may not be blank : ";
            }
            if(firstName.Length > 50)
            {
                Error = Error + "The first name may not exceed 50 characters : ";
            }
            // Start date validation
            try
            {
                TempDate = Convert.ToDateTime(startDate);
                if (TempDate < DateTime.Now.Date)
                {
                    Error = Error + "The date cannot be in the past : ";
                }
                if (TempDate > DateTime.Now.Date.AddMonths(1))
                {
                    Error = Error + "The date cannot be more than a month in the future : ";
                }
            }
            catch
            {
                Error = Error + "The date was not a valid date : ";
            }
            // Last name validation
            if(lastName.Length == 0)
            {
                Error = Error + "The last name may not be blank : ";
            }
            if(lastName.Length > 50)
            {
                Error = Error + "The last name may not exceed 50 characters : ";
            }
            // Email address validation
            if(emailAddress.Length > 100)
            {
                Error = Error + "The email address may not exceed 100 characters : ";
            }
            // Home address validation
            if(homeAddress.Length > 200)
            {
                Error = Error + "The home address may not exceed 200 characters : ";
            }

            return Error;
        }
    }
}