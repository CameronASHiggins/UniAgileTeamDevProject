using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class clsItemCollection
    {
        //Private data member for the list
        List<clsStock> mItemList = new List<clsStock>();
        private clsStock mThisItem = new clsStock();

        //constructor for the class
        public clsItemCollection()
        {
            //var for the index
            Int32 Index = 0;
            //var to store the record count
            Int32 RecordCount = 0;
            //object for data connection
            clsDataConnection DB = new clsDataConnection();
            //execture the stored procedure for selecting all records
            DB.Execute("sproc_tblStock_SelectAll");
            //get the count of records
            PopulateArray(DB);
        }

        public List<clsStock> ItemList
        {
            get
            {
                //return the private data
                return mItemList;
            }
            set
            {
                //set the private data
                mItemList = value;
            }
        }
        public int Count
        {
            get
            {
                //return the private data
                return mItemList.Count;
            }
            set
            {
                //Later
            }
        }
        public clsStock ThisItem
        {
            get
            {
                return mThisItem;
            }
            set
            {
                mThisItem = value;
            }
        }

        public int Add()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@ItemID", mThisItem.ItemID);
            DB.AddParameter("@Available", mThisItem.Available);
            DB.AddParameter("@ItemName", mThisItem.ItemName);
            DB.AddParameter("@ItemType", mThisItem.ItemType);
            DB.AddParameter("@StockQuantity", mThisItem.StockQuantity);
            DB.AddParameter("@Price", mThisItem.Price);
            DB.AddParameter("@Supplier", mThisItem.Supplier);
            DB.AddParameter("@NextRestock", mThisItem.NextRestock);

            return DB.Execute("sproc_tblStock_Insert");
        }

        public void Update()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@ItemID", mThisItem.ItemID);
            DB.AddParameter("@Available", mThisItem.Available);
            DB.AddParameter("@ItemName", mThisItem.ItemName);
            DB.AddParameter("@ItemType", mThisItem.ItemType);
            DB.AddParameter("@StockQuantity", mThisItem.StockQuantity);
            DB.AddParameter("@Price", mThisItem.Price);
            DB.AddParameter("@Supplier", mThisItem.Supplier);
            DB.AddParameter("@NextRestock", mThisItem.NextRestock);

            DB.Execute("sproc_tblStock_Update");
        }

        public void Delete()
        {
            clsDataConnection DB = new clsDataConnection();
            DB.AddParameter("@ItemID", mThisItem.ItemID);
            DB.Execute("sproc_tblStock_Delete");
        }

        public void ReportByItemType(string ItemType)
        {
            //Filters the records based on a full or partial ItemType
            //connect to the database
            clsDataConnection DB = new clsDataConnection();
            //send the itemtype parameter to the database
            DB.AddParameter("@ItemType", ItemType);
            //execute the stored procedure
            DB.Execute("sproc_tblStock_FilterByItemType");
            //Populate the array list with the data table
            PopulateArray(DB);
        }

        void PopulateArray(clsDataConnection DB)
        {
            //populates the array list based on the data table in the parameter DB
            Int32 Index = 0;
            Int32 RecordCount;
            RecordCount = DB.Count;
            mItemList = new List<clsStock>();
            while (Index < RecordCount)
            {
                //create a blank item
                clsStock AnItem = new clsStock();
                //read in the fields from the current record
                AnItem.Available = Convert.ToBoolean(DB.DataTable.Rows[Index]["Available"]);
                AnItem.ItemID = Convert.ToInt32(DB.DataTable.Rows[Index]["ItemID"]);
                AnItem.ItemName = Convert.ToString(DB.DataTable.Rows[Index]["ItemName"]);
                AnItem.ItemType = Convert.ToString(DB.DataTable.Rows[Index]["ItemType"]);
                AnItem.StockQuantity = Convert.ToInt32(DB.DataTable.Rows[Index]["StockQuantity"]);
                AnItem.Price = Convert.ToDouble(DB.DataTable.Rows[Index]["Price"]);
                AnItem.Supplier = Convert.ToString(DB.DataTable.Rows[Index]["Supplier"]);
                AnItem.NextRestock = Convert.ToDateTime(DB.DataTable.Rows[Index]["NextRestock"]);
                //add the record to the private data member
                mItemList.Add(AnItem);
                //point at the next record
                Index++;
            }
        }
    }
}